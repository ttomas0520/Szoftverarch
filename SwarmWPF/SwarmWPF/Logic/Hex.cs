using HexGridHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.Logic {
    public class Hex : INotifyPropertyChanged {
        private IntPoint _point;

        public event PropertyChangedEventHandler PropertyChanged;

        public IntPoint Point {
            get { return _point; }
            set {
                if (_point != value) {
                    _point = value;
                    OnPropertyChanged(nameof(Point));
                }
            }
        }
        public bool HasAnt { get; set; }
        public bool IsReserved { get; set; }
        public List<Hex> Neighbours { get; set; }
        public int Priority { get; set; }

        public Hex(int row, int column) {
            Point = new IntPoint(row, column);
        }

        public void ReserveNext() {
            if (!HasAnt) return;
        }
        public void ChangeFirstNeighbor() {
            Neighbours.First().Point.Ant = "asd";
        }
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
