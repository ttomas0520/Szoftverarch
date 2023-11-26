using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.ViewModel {
    class EmptyHex : Hex {
        public EmptyHex(int row, int column, bool isAnt) : base(row, column, "Gainsboro", isAnt) {

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
