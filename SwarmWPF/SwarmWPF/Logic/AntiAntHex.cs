using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.Logic {
    class AntiAntHex : Hex {
        public AntiAntHex(int row, int column, bool isAnt) : base(row, column, "LightGreen", isAnt) {

        }

        public override void ReserveNext() {
            if (this.Point.Ant != "X") return;
            var neighbours_hasAnt = Neighbours.FindAll(x => x.Point.Ant == "X").ToList();

            if (neighbours_hasAnt.Count == 0) {
                Stay();
                return;
            }
            var neighbours_notReserved = Neighbours.FindAll(x => x.ReservedBy == null && x.Point.Ant != "X").ToList();

            if (neighbours_notReserved.Count == 0) {
                Stay();
                return;
            }


            var random = new Random();
            neighbours_notReserved[random.Next(neighbours_notReserved.Count)].ReservedBy = this;
            return;
        }
    }
}
