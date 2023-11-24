using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.Logic {
    public class Board {
        public int Row { get; set; }
        public int Column { get; set; }
        public List<List<Hex>> HexList { get; set; }
        public Board(int row, int column) {
            Row = row;
            Column = column;
            HexList = createHexList(row, column);
        }
        public void CalculateNextRound() {
            foreach (var rowList in HexList) {
                foreach (var hex in rowList) {
                    hex.ReserveNext();
                }
            }


        }

        private List<List<Hex>> createHexList(int row, int column) {
            List<List<Hex>> hexList = new List<List<Hex>>();

            for (int i = 0; i < row; i++) {
                List<Hex> rowList = new List<Hex>();
                for (int j = 0; j < column; j++) {
                    Hex hex = new Hex();
                    rowList.Add(hex);
                }
                hexList.Add(rowList);
            }

            return hexList;
        }
    }
}
