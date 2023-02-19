using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinBusinessLayer.Entities
{
    public class Cell
    {

        public int PressedBy;
        public int Winner;
        public bool IsMatchEnded;

        public Cell(int pressedBy, int winner, bool isMatchEnded) {
            this.PressedBy = pressedBy;
            this.Winner = winner;
            this.IsMatchEnded = isMatchEnded;
        }


    }
}
