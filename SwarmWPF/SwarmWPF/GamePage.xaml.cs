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
using System.Windows.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SwarmWPF {
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page, INotifyPropertyChanged
    {
        private int _round;

        private readonly MainWindow mainWindow;
        public int Row { get; set; }
        public int Column { get; set; }
        public int Round { get { return _round; } set { _round = value; OnPropertyChanged(); } }
        public int Ant_Percentage {  get; set; }
        public Board Gameboard { get; set; }
        private DispatcherTimer timer;

        public event PropertyChangedEventHandler? PropertyChanged;

        public GamePage(MainWindow mainWindow, int row, int column, int ant_Percentage)
        {
            this.mainWindow = mainWindow;
            Row = row;
            Column = column;
            Gameboard = new Board(row, column, ant_Percentage);
            Round = 1;
            InitializeComponent();
            Board.ItemsSource = Gameboard.HexList
                .SelectMany(rowList => rowList)
                .Select(hex => hex.Point)
                .ToList();
            DataContext = this;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Az időzítési időköz beállítása (1 másodperc)
            timer.Tick += Timer_Tick;
            NextRound();
            Ant_Percentage = ant_Percentage;
        }
        private void HexTypeChanger(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            if (button != null) {
                // Get the HexItem from the button's Tag attribute
                IntPoint intPoint = (IntPoint)button.Tag;

                // Open the color selection window
                var colorSelectionWindow = new HexTypeSelectionWindow();
                if (colorSelectionWindow.ShowDialog() == true) {
                    // User selected a color
                    string selectedHexType = colorSelectionWindow.SelectedType;
                    switch (selectedHexType)
                    {
                        case "AntiAntHex": {
                                var newAntiAntHex = new AntiAntHex(intPoint.X,intPoint.Y,"",intPoint.Ant=="X");
                                newAntiAntHex.Neighbours = Gameboard.HexList[intPoint.X][intPoint.Y].Neighbours;
                                Gameboard.HexList[intPoint.X][intPoint.Y] = newAntiAntHex;

                                break; }
                        default: break;
                    }

                    // Change the hex color
                    //Gameboard.ChangeHexColor(intPoint.X, intPoint.Y, selectedColor, intPoint.Ant != null);

                    // Update the HexList
                    Board.ItemsSource = Gameboard.HexList
                        .SelectMany(rowList => rowList)
                        .Select(hex => hex.Point)
                        .ToList();
                }
            }
        }
        public void NextRound() {
            var simulationRound = new Simulation() { Board = Gameboard, Round = Round };
            mainWindow.InsertRound(simulationRound);
        }


        private void play_Click(object sender, RoutedEventArgs e) {
            timer.Start();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {           
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Round++;
            // Az eredeti kódot ide helyezzük be, amit 1 másodpercenként szeretnénk futtatni
            Gameboard.CalculateNextRound();
            Board.ItemsSource = Gameboard.HexList
                .SelectMany(rowList => rowList)
                .Select(hex => hex.Point)
                .ToList();
            Trace.WriteLine("tick");
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
