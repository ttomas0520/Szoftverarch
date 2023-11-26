using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.ViewModel {
    class UpRightHex : Hex {
        public UpRightHex(int row, int column, bool isAnt) : base(row, column, "Gold", isAnt) {
        }

        public override void ReserveNext() {
            if (this.Point.Ant != "X") return;
            var searchedY = this.Point.Y+1;
            var searchedX = this.Point.X;
            if (Point.Y % 2 == 0) { searchedX--; }
            var upNeighbour = Neighbours.FirstOrDefault(x => x.Point.X == searchedX && x.Point.Y == searchedY);

            if (upNeighbour == null || upNeighbour.ReservedBy != null) {
                Stay();
                return;
            }
            upNeighbour.ReservedBy = this;
            return;
        }
    }
}
