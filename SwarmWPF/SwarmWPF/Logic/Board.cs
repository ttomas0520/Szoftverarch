using HexGridHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.Logic {
    public class Board : INotifyPropertyChanged {
        private List<List<Hex>> _hexlist;
        public int Row { get; set; }
        public int Column { get; set; }
        public List<List<Hex>> HexList { get { return _hexlist; } set { _hexlist = value; OnPropertyChanged(); } }
        public Board(int row, int column, int percentage) {
            Row = row;
            Column = column;
            HexList = createHexList(row, column, percentage);
            ConnectHexNeighbors();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void CalculateNextRound() {
            foreach (var rowList in HexList) {
                foreach (var hex in rowList) {
                    hex.ReserveNext();
                }
            }

            foreach (var rowList in HexList) {
                foreach (var hex in rowList) {
                    hex.StepNext();
                }
            }

        }



        private List<List<Hex>> createHexList(int row, int column, int percentage) {
            List<List<Hex>> hexList = new List<List<Hex>>();
            var all = row * column;
            int entites = all * percentage / 100;
            List<bool> isAnt = new List<bool>();
            for (int i = 0; i < all; i++) {
                if (i < entites) isAnt.Add(true);
                else {
                    isAnt.Add(false);
                }
            }
            isAnt = isAnt.OrderBy(x => Random.Shared.Next()).ToList();

            for (int i = 0; i < row; i++) {
                List<Hex> rowList = new List<Hex>();
                for (int j = 0; j < column; j++) {
                    Hex hex = new Hex(i, j, "white", isAnt[i * column + j]);
                    rowList.Add(hex);
                }
                hexList.Add(rowList);
            }
            return hexList;
        }

        private void ConnectHexNeighbors() {
            for (int i = 0; i < Row; i++) {
                for (int j = 0; j < Column; j++) {
                    Hex hex = HexList[i][j];
                    hex.Neighbours = GetHexNeighbors(i, j);
                }
            }
        }

        private List<Hex> GetHexNeighbors(int row, int column) {
            List<Hex> neighbors = new List<Hex>();

            // Define the six possible neighbors' coordinates
            if (column % 2 == 0) {
                int[,] neighborCoords = {
                    { -1, 0 }, { -1, 1 }, { 0, 1 },
                    { 1, 0 }, { 0, -1 }, { -1, -1 }
                };

                for (int k = 0; k < 6; k++) {
                    int neighborRow = row + neighborCoords[k, 0];
                    int neighborColumn = column + neighborCoords[k, 1];

                    // Check if the neighbor coordinates are within the board bounds
                    if (neighborRow >= 0 && neighborRow < Row && neighborColumn >= 0 && neighborColumn < Column) {
                        neighbors.Add(HexList[neighborRow][neighborColumn]);
                    }
                }

                return neighbors;
            }
            else {
                int[,] neighborCoords = {
                { -1, 0 }, { 0, 1 }, { 1, 1 },
                { 1, 0 }, { 1, -1 }, { 0, -1 }
            };

                for (int k = 0; k < 6; k++) {
                    int neighborRow = row + neighborCoords[k, 0];
                    int neighborColumn = column + neighborCoords[k, 1];

                    // Check if the neighbor coordinates are within the board bounds
                    if (neighborRow >= 0 && neighborRow < Row && neighborColumn >= 0 && neighborColumn < Column) {
                        neighbors.Add(HexList[neighborRow][neighborColumn]);
                    }
                }

                return neighbors;
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
