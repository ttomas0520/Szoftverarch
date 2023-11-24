using HexGridHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.Logic {
    public class Hex {
        public IntPoint Point { get; set; }
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

    }
}
