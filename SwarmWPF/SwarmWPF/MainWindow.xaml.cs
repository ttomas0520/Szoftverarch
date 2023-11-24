using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using HexGridHelpers;
using MongoDB.Bson;
using MongoDB.Driver;
using Repositories;
using Swarm.Repositories;
using SwarmWPF.Logic;
using SwarmWPF.Models.DatabaseModels;

namespace SwarmWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private ISimulationRepository _simulationRepository;
        public MainWindow() {
            _simulationRepository = new SimulationRepository();
            InitializeComponent();
            NavigateToStartPage();
        }

        private void NavigateToStartPage() {
            mainFrame.Navigate(new MenuPage(this));
        }
        public void InsertRound(Simulation simulation) {
            _simulationRepository.InsertOneAsync(simulation);
        }
        public async void LoadGame(string gameId) {
            var loadedGame = await _simulationRepository.GetSimulationsByIdsAsync(gameId);
            mainFrame.Navigate(new LoadedGamePage(this, loadedGame));

        }
    }
}
