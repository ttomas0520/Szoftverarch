using HexGridHelpers;
using SwarmWPF.Logic;
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
        public int Row { get; set; }
        public int Column { get; set; }
        public Board board { get; set; }
        public GamePage(int row, int column) {
            Row = row;
            Column = column;
            board = new Board(row, column);
            InitializeComponent();
            Board.ItemsSource =
                   Enumerable.Range(0, row)
                       .SelectMany(r => Enumerable.Range(0, column)
                           .Select(c => new IntPoint(c, r)))
                       .ToList();
            DataContext = this;
        }

    }
}
