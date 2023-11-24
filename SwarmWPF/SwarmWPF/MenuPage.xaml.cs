using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private readonly MainWindow mainWindow;

        public MenuPage(MainWindow mainWindow) {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        private void OnStartGameClicked(object sender, RoutedEventArgs e) {
            // Create an instance of GamePage


            // Parse the values from TextBoxes and set RowCount and ColumnCount
            if (int.TryParse(BoardHeight.Text, out int rowCount) && int.TryParse(BoardWidth.Text, out int columnCount)) {
                GamePage gamePage = new GamePage(rowCount, columnCount);
                mainWindow.mainFrame.Navigate(gamePage);
            }
            else {
                // Handle invalid input (e.g., show an error message)
                MessageBox.Show("Invalid input for RowCount or ColumnCount. Please enter valid integer values.");
                return;
            }
        }

        private void OnLoadGameClicked(object sender, RoutedEventArgs e) {
            // Implement the logic for the Load Game button click
            MessageBox.Show("Load Game button clicked!");
        }

        private void OnExitGameClicked(object sender, RoutedEventArgs e) {
            // Implement the logic to close the application
            Application.Current.Shutdown();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
