using System;

namespace HexGridHelpers {
    public struct IntPoint : IEquatable<IntPoint> {
        private readonly int _x;
        private readonly int _y;
        private string _ant;


        public IntPoint(int x, int y) {
            _x = x;
            _y = y;
            if ((x + y) % 2 == 0) { _ant = "X"; }
            else { _ant = ""; }
        }

        public int X {
            get { return _x; }
        }

        public int Y {
            get { return _y; }
        }
        public string Ant {
            get { return _ant; }
        }

        public static bool operator ==(IntPoint a, IntPoint b) {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(IntPoint a, IntPoint b) {
            return !(a == b);
        }

        public bool Equals(IntPoint other) {
            return this == other;
        }
    }
}
