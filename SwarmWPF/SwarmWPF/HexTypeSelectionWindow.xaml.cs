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
using System.Windows.Shapes;

namespace SwarmWPF {
    /// <summary>
    /// Interaction logic for HexTypeSelectionWindow.xaml
    /// </summary>
    public partial class HexTypeSelectionWindow : Window {
        public string SelectedType { get; private set; }

        public HexTypeSelectionWindow() {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e) {
            if (ColorListBox.SelectedItem != null) {
                SelectedType = ((ListBoxItem)ColorListBox.SelectedItem).Content.ToString();
                DialogResult = true;
            }
            else {
                MessageBox.Show("Please select a color.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
