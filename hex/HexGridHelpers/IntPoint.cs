using System;
using System.ComponentModel;

namespace HexGridHelpers {
    public struct IntPoint : IEquatable<IntPoint>, INotifyPropertyChanged {
        private readonly int _x;
        private readonly int _y;
        private string _ant;
        private string _color;

        public event PropertyChangedEventHandler PropertyChanged;

        public IntPoint(int x, int y, string color) {
            _x = x;
            _y = y;
            if ((x + y) % 2 == 0) { _ant = "X"; }
            else { _ant = ""; };
            _color = color;
            PropertyChanged = null;

        }

        public int X {
            get { return _x; }
        }

        public int Y {
            get { return _y; }
        }
        public string Ant {
            get { return _ant; }
            set {
                if (_ant != value) {
                    _ant = value;
                    OnPointChanged("Ant");
                }
            }
        }

        public void SetAnt(string ant) {
            if (_ant != ant) {
                _ant = ant;
                OnPointChanged("Ant");
            }
        }
        public string Color {
            get { return _color; }
            set { _color = value; }
        }

        public void OnPointChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public static bool operator ==(IntPoint a, IntPoint b) {
            return a.X == b.X && a.Y == b.Y && a.Ant == b.Ant && a.Color == b.Color;
        }

        public static bool operator !=(IntPoint a, IntPoint b) {
            return !(a == b);
        }

        public bool Equals(IntPoint other) {
            return this == other;
        }
    }
}
