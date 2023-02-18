using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Controller
    {
        public int LastPlayer { get; set; }
        public int NumberOfCellsPressed { get; set; }
        public WinningCombinations WinningCombinations;
        public int NumberOfPlayers { get; set; }

        public Controller(int NumberOfPlayers)
        {
            this.NumberOfCellsPressed = 0;
            this.WinningCombinations = new WinningCombinations();
            this.NumberOfPlayers = NumberOfPlayers;
            int startingPlayer = this.NumberOfPlayers == 1 ? ExtractRandomPlayer() : 1;
            SetLastPlayer(startingPlayer);
        }


        public Cell CellPressed(int pressedCell)
        {
            this.NumberOfCellsPressed++;
            bool isMatchEnded = this.NumberOfCellsPressed == 9 ? true : false;
            this.LastPlayer = this.LastPlayer == 1 ? 2 : 1;
            Cell cell = new Cell(this.LastPlayer, 0, isMatchEnded);
            this.WinningCombinations.UpdateCombinations(pressedCell, this.LastPlayer);
            cell.Winner = this.WinningCombinations.IsWinner();
            return cell;
        }

        public int ExtractRandomPlayer()
        {
            var rand = new Random();
            double randValue = rand.NextDouble();
            int selectedPlayer = randValue > 0.5 ? 2 : 1;
            return selectedPlayer;
        }

        public void SetLastPlayer(int startingPlayer)
        {
            this.LastPlayer = startingPlayer == 1 ? 2 : 1; 
        }

    }
}
