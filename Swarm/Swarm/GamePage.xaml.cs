using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Swarm {
    public partial class GamePage : ContentPage {
        public ObservableCollection<HexagonViewModel> Hexagons { get; } = new ObservableCollection<HexagonViewModel>();

        public GamePage() {
            InitializeComponent();
            InitializeHexagons(20, 15);
            BindingContext = this;
        }

        private void InitializeHexagons(int rows, int columns) {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    double x = (3.0 / 2 * j) * 100;
                    double y = (Math.Sqrt(3) * i + (j % 2 == 1 ? Math.Sqrt(3) / 2 * 100 : 0)) * 100;

                    Hexagons.Add(new HexagonViewModel {
                        Color = i % 2 == 0 ? "Red" : "Green",
                        TapCommand = new Command(() => HandleTap()),
                        HexagonPoints = CalculateHexagonPoints(x, y, 50)
                    });
                }
            }

            // Dynamically add Polygon elements to the Grid
            for (int i = 0; i < Hexagons.Count; i++) {
                var hexagon = Hexagons[i];
                var polygon = new Polygon {
                    Points = new PointCollection(hexagon.HexagonPoints),
                    Fill = Brush.Default,
                    Stroke = Brush.Default,
                    Aspect = Stretch.Fill,
                    StrokeThickness = 5,
                    HeightRequest = 100,
                    WidthRequest = 100
                };

                polygon.GestureRecognizers.Add(new TapGestureRecognizer {
                    Command = hexagon.TapCommand
                });

                Grid.SetRow(polygon, i / columns);
                Grid.SetColumn(polygon, i % columns);
                HexagonGrid.Children.Add(polygon);
            }
        }

        private Point[] CalculateHexagonPoints(double centerX, double centerY, double radius) {
            Point[] points = new Point[6];

            for (int i = 0; i < 6; i++) {
                double angle = 2.0 * Math.PI / 6 * i;
                double x = centerX + radius * Math.Cos(angle);
                double y = centerY + radius * Math.Sin(angle);
                points[i] = new Point(x, y);
            }

            return points;
        }

        private void HandleTap() {
            // Handle tap event
            // You can add logic here to respond to the tap gesture on hexagons
        }
    }

    public class HexagonViewModel {
        public string Color { get; set; }
        public ICommand TapCommand { get; set; }
        public Point[] HexagonPoints { get; set; }
    }
}
