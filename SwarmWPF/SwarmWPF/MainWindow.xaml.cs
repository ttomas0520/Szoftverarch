using System;
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
            NavigateToStartPage();
        }

        private void NavigateToStartPage() {
            mainFrame.Navigate(new MenuPage(this));
        }
    }
}
