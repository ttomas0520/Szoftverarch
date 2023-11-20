using Microsoft.Maui.Controls;
using Repositories;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Swarm {
    public partial class GamePage : ContentPage {
        private readonly ISimulationRepository _repository;
        public ObservableCollection<HexagonViewModel> Hexagons { get; } = new ObservableCollection<HexagonViewModel>();

        public GamePage(ISimulationRepository repository) {
            _repository = repository;
            InitializeComponent();
            InitializeHexagons(3, 3);
            BindingContext = this;
        }

        private void InitializeHexagons(int rows, int columns) {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    double x = j * 1.5 * 100;
                    double y = i * Math.Sqrt(3) * 100;

                    // Shift odd columns downward by half a hexagon
                    if (j % 2 == 1) {
                        y += Math.Sqrt(3) * 50;
                    }

                    Hexagons.Add(new HexagonViewModel {
                        Color = i % 2 == 0 ? "Red" : "Green",
                        TapCommand = new Command(() => HandleTap()),
                        HexagonPoints = CalculateHexagonPoints(x, y, 50)
                    });
                }
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
