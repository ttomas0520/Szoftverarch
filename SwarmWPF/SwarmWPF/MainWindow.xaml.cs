using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using HexGridHelpers;


namespace SwarmWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            Board.ItemsSource =
                Enumerable.Range(0, Board.RowCount)
                    .SelectMany(r => Enumerable.Range(0, Board.ColumnCount)
                        .Select(c => new IntPoint(c, r)))
                    .ToList();
        }

        private void MenuClick(object sender, RoutedEventArgs e) {
            var button = sender as Button;
            if (button == null)
                return;

            MessageBox.Show(button.Content.ToString(), "HexMenu", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
