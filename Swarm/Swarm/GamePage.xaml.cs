
using Microsoft.Maui.Controls.Shapes;

namespace Swarm {
    public partial class GamePage : ContentPage {
        public GamePage() {
            InitializeComponent();
        }
        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) {
            var polygon = (Polygon)sender;
            polygon.Fill = new SolidColorBrush(Colors.Red);
        }
    }

}
