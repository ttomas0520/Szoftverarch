using SwarmWPF.Logic;
using SwarmWPF.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace SwarmWPF {
    /// <summary>
    /// Interaction logic for LoadedGamePage.xaml
    /// </summary>
    public partial class LoadedGamePage : Page, INotifyPropertyChanged {
        private readonly List<Simulation> gameRounds;
        private DispatcherTimer timer;
        private int _round;
        public int Round { get { return _round; } set { _round = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler? PropertyChanged;
        public int Row { get; set; }
        public int Column { get; set; }
        public BoardDTO Gameboard { get; set; }

        public LoadedGamePage(List<Simulation> gameRounds) {
            this.gameRounds = gameRounds;
            Round = 1;
            LoadGameBoard(Round);
            Row = Gameboard.Row;
            Column = Gameboard.Column;
            InitializeComponent();
            Board.ItemsSource = Gameboard.HexList
                .SelectMany(rowList => rowList)
                .Select(hex => hex)
                .ToList();
            DataContext = this;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Az időzítési időköz beállítása (1 másodperc)
            timer.Tick += Timer_Tick;
        }


        public void LoadGameBoard(int roundCount) {
            Gameboard = gameRounds[roundCount - 1].Board;
        }
        private void play_Click(object sender, RoutedEventArgs e) {
            timer.Start();
        }

        private void stop_Click(object sender, RoutedEventArgs e) {
            timer.Stop();
        }
        private void Timer_Tick(object sender, EventArgs e) {
            if (gameRounds.Count > Round) {
                Round++;
                LoadGameBoard(Round);
                Board.ItemsSource = Gameboard.HexList
                .SelectMany(rowList => rowList)
                .Select(hex => hex)
                .ToList();
                Trace.WriteLine("tick");
            }
        }
        private void PreviousStep(object sender, EventArgs e) {
            if (gameRounds.Count >= Round && Round > 1) {
                Round--;
                LoadGameBoard(Round);
                Board.ItemsSource = Gameboard.HexList
                .SelectMany(rowList => rowList)
                .Select(hex => hex)
                .ToList();
                Trace.WriteLine("tick");
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
