using HexGridHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.ViewModel {
    public class Hex {
        private IntPoint _point;


        public IntPoint Point {
            get { return _point; }
            set {

                _point = value;
            }
        }
        public Hex? ReservedBy { get; set; }
        public List<Hex> Neighbours { get; set; }

        public Hex(int row, int column, string color, bool isAnt) {
            Point = new IntPoint(row, column, color, isAnt);
        }

        public virtual void ReserveNext() {
            if (this.Point.Ant == "X") {
                if (this.ReservedBy != null) {
                    this.ReservedBy.ReserveNext();
                }
                this.ReservedBy = this;

            }
        }

        public void Stay() {
            if (this.ReservedBy != null && this.ReservedBy != this) {
                this.ReservedBy.ReserveNext();
            }
            this.ReservedBy = this;
        }

        public virtual void StepNext() {
            if (ReservedBy != null) {
                _point.SetAnt(true);
                this.ReservedBy = null;
            }
            else {
                _point.SetAnt(false);
            }
        }
    }
}
