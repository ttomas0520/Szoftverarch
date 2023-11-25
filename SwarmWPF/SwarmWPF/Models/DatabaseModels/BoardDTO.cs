using HexGridHelpers;
using SwarmWPF.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SwarmWPF.Models.DatabaseModels {
    public class BoardDTO {
        private List<List<IntPoint>> _hexlist;
        public int Row { get; set; }
        public int Column { get; set; }
        public List<List<IntPoint>> HexList { get { return _hexlist; } set { _hexlist = value; } }
        public BoardDTO(int row, int column, List<List<IntPoint>> hexList) {
            Row = row;
            Column = column;
            HexList = hexList;
        }
    }
}
