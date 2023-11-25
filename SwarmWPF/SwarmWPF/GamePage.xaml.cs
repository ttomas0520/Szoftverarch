using HexGridHelpers;
using Repositories;
using SwarmWPF.Logic;
using SwarmWPF.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwarmWPF {
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page {
        private readonly MainWindow mainWindow;
        public int Row { get; set; }
        public int Column { get; set; }
        public int Round { get; set; }
        public Board Gameboard { get; set; }
        public GamePage(MainWindow mainWindow, int row, int column) {
            this.mainWindow = mainWindow;
            Row = row;
            Column = column;
            Gameboard = new Board(row, column);
            Round = 1;
            InitializeComponent();
            Board.ItemsSource = Gameboard.HexList
                .SelectMany(rowList => rowList)
                .Select(hex => hex.Point)
                .ToList();
            DataContext = this;
            NextRound();
        }
        private void MenuClick(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            if (button != null) {
                // Az OriginalSource-on keresztül hozzáférünk a gomb Tag attribútumához rendelt HexItem objektumhoz
                IntPoint intPoint = (IntPoint)button.Tag;
                Gameboard.ChangeHexColor(intPoint.X, intPoint.Y, "Blue");
                MessageBox.Show(intPoint.X.ToString(), "HexMenu", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Board.ItemsSource = Gameboard.HexList
                .SelectMany(rowList => rowList)
                .Select(hex => hex.Point)
                .ToList();
            }



        }
        public void NextRound() {
            var simulationRound = new Simulation() { Board = Gameboard, Round = Round };
            mainWindow.InsertRound(simulationRound);
        }


        private void play_Click(object sender, RoutedEventArgs e) {
            Gameboard.ChangeHex();
            Board.ItemsSource = Gameboard.HexList
                .SelectMany(rowList => rowList)
                .Select(hex => hex.Point)
                .ToList();
        }
    }
}
