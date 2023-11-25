using HexGridHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.Logic {
    public class Hex {
        private IntPoint _point;


        public IntPoint Point {
            get { return _point; }
            set {
                if (_point != value) {
                    _point = value;


                }
            }
        }
        public bool HasAnt { get; set; }
        public bool IsReserved { get; set; }
        public List<Hex> Neighbours { get; set; }
        public int Priority { get; set; }

        public Hex(int row, int column, string color, bool isAnt) {
            Point = new IntPoint(row, column, color, isAnt);
        }

        public void ReserveNext() {
            if (!HasAnt) return;
        }
        public void ChangeFirstNeighbor() {
            var firstNeighbor = Neighbours.First();
            var point = firstNeighbor.Point;
            point.Ant = "asd";
            Neighbours.First().Point = point;
        }
    }
}
