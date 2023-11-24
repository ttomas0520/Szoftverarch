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
    /// Interaction logic for LoadedGamePage.xaml
    /// </summary>
    public partial class LoadedGamePage : Page {
        private readonly MainWindow mainWindow;
        private readonly List<Simulation> gameRounds;
        public LoadedGamePage(MainWindow mainWindow, List<Simulation> gameRounds) {
            this.mainWindow = mainWindow;
            this.gameRounds = gameRounds;
            InitializeComponent();
        }
    }
}
