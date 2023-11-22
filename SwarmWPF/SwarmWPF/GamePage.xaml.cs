using HexGridHelpers;
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
        public GamePage() {
            InitializeComponent();
            Board.ItemsSource =
                   Enumerable.Range(0, Board.RowCount)
                       .SelectMany(r => Enumerable.Range(0, Board.ColumnCount)
                           .Select(c => new IntPoint(c, r)))
                       .ToList();
        }

    }
}
