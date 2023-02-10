using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Entities
{
    public class Controller
    {
        internal int LastPlayer { get; set; }
        internal int PressedCells { get; set; }
        internal WinningCombinations WinningCombinations;
        internal int PlayersNumber { get; set; }

        public Controller(int playersNumber)
        {
            this.PressedCells = 0;
            this.WinningCombinations = new WinningCombinations();
            this.PlayersNumber = playersNumber;

            if (this.PlayersNumber == 1) {
                int startingPlayer = ExtractRandomPlayer();
                if (startingPlayer == 1) {
                    this.LastPlayer = 2;
                } else
                {
                    this.LastPlayer = 1;
                }
            } else
            {
                this.LastPlayer = 2;
            }
        }


        public Cell CellPressed(int pressedCell)
        {
            bool isMatchEnded;
            this.PressedCells++;
            Console.WriteLine(this.PressedCells.ToString());

            if (this.PressedCells == 9)
            {
                isMatchEnded = true;
            } else
            {
                isMatchEnded = false;
            }

            Cell cell;
            if (this.LastPlayer == 1)
            {
                this.LastPlayer = 2;
                cell = new Cell(2, 0, isMatchEnded);
            } else
            {
                this.LastPlayer = 1;
                cell = new Cell(1, 0, isMatchEnded);
            }

            this.WinningCombinations.UpdateCombinations(pressedCell, this.LastPlayer);

            cell.Winner = this.WinningCombinations.IsWinner();

            return cell;
        }

        public int ExtractRandomPlayer()
        {
            var rand = new Random();
            double randValue = rand.NextDouble();

            if (randValue > 0.5)
            {
                return 2;
            } else
            {
                return 1;
            }
        }

    }
}
