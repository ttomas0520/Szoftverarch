using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.Logic {
    class EmptyHex : Hex {
        public EmptyHex(int row, int column, string color, bool isAnt) : base(row, column, "Gainsboro", isAnt) {

        }

        public override void ReserveNext() {
            Stay();
            return;
        }

        public override void StepNext() {
            return;
        }
    }
}
