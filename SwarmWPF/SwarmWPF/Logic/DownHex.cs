using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.Logic {
    class DownHex : Hex {
        public DownHex(int row, int column, bool isAnt) : base(row, column, "PaleTurquoise", isAnt) {
        }

        public override void ReserveNext() {
            if (this.Point.Ant != "X") return;
            var upNeighbour = Neighbours.FirstOrDefault(x => x.Point.X == this.Point.X + 1);

            if (upNeighbour == null || upNeighbour.ReservedBy != null) {
                Stay();
                return;
            }
            upNeighbour.ReservedBy = this;
            return;
        }
    }
}
