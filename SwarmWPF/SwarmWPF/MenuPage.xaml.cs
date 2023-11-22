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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page {
        private MainWindow mainWindow;

        public MenuPage(MainWindow mainWindow) {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        private void OnStartGameClicked(object sender, RoutedEventArgs e) {
            // Navigate to the GamePage
            mainWindow.mainFrame.Navigate(new GamePage());
        }

        private void OnLoadGameClicked(object sender, RoutedEventArgs e) {
            // Implement the logic for the Load Game button click
            MessageBox.Show("Load Game button clicked!");
        }

        private void OnExitGameClicked(object sender, RoutedEventArgs e) {
            // Implement the logic to close the application
            Application.Current.Shutdown();
        }
    }
}
