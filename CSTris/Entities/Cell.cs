using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Entities
{
    public class Cell
    {

        internal int PressedBy;
        internal int Winner;
        internal bool IsMatchEnded;

        public Cell(int pressedBy, int winner, bool isMatchEnded) {
            this.PressedBy = pressedBy;
            this.Winner = winner;
            this.IsMatchEnded = isMatchEnded;
        }


    }
}
