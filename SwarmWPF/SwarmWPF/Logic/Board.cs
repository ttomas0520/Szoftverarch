﻿using System;
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
                    Hex hex = new Hex(i, j);
                    rowList.Add(hex);
                }
                hexList.Add(rowList);
            }
            ConnectHexNeighbors();
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
            int[,] neighborCoords = {
            { -1, 0 }, { -1, 1 }, { 0, 1 },
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
}
