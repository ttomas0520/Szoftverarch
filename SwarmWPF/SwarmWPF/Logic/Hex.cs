using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.Logic {
    public class Hex {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool HasAnt { get; set; }
        public bool IsReserved { get; set; }
        public List<Hex> Neighbours { get; set; }
        public int Priority { get; set; }

        public Hex() { }

        public void ReserveNext() {
            if (!HasAnt) return;
        }
    }
}
