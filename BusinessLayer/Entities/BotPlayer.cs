using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class BotPlayer
    {

        public int StartingPlayer;
        public int NumberOfCellsPressed;
        public WinningCombinations WinningCombinations = new WinningCombinations();

        public BotPlayer(int lastPlayer)
        {
            this.StartingPlayer = lastPlayer == 1 ? 2 : 1;
            this.NumberOfCellsPressed = 0;
        }

        public int PressCell()
        {
            int pressedCell;
            if (HasToAttack())
            {
                pressedCell = Attacks();
            }
            else if (HasToStartFromTheCenter())
            {
                pressedCell = 5;
            }
            else
            {
                pressedCell = Defends();
            }
            return pressedCell;
        }

        private bool HasToAttack()
        {
            return (this.StartingPlayer == 2) || (this.NumberOfCellsPressed == 1 && this.StartingPlayer == 1 && !(IsCellAvailable(5)));
        }

        private bool HasToStartFromTheCenter()
        {
            return this.NumberOfCellsPressed == 1 && this.StartingPlayer == 1 && IsCellAvailable(5);
        }

        public void Update(WinningCombinations winningCombinations, int NumberOfCellsPressed)
        {
            this.WinningCombinations = winningCombinations;
            this.NumberOfCellsPressed = NumberOfCellsPressed;
        }

        public int ExtractRandomCell(int[] cellArray)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, cellArray.Length);
            return cellArray[randomIndex];
        }

        public int Attacks()
        {
            int pressedCell;
            Combination[] playerTwoCombinationArray = FindTwoCellPlayer(2);
            if (playerTwoCombinationArray.Length == 0)
            {
                Combination[] playerOneCombinationArray = FindTwoCellPlayer(1);
                if (playerOneCombinationArray.Length == 0)
                {
                    List<int> cellList = new List<int>();
                    int[] cellArray = new int[4] { 1, 3, 7, 9 };
                    for (int i = 0; i < 4; i++)
                    {
                        if (IsCellAvailable(cellArray[i]))
                        {
                            cellList.Add(cellArray[i]);
                        }
                    }
                    cellArray = cellList.ToArray();
                    pressedCell = cellArray.Length > 0 ? ExtractRandomCell(cellArray) : GetEmptyCell();
                } else
                {
                    pressedCell = ChooseCell(playerOneCombinationArray);
                }
            }
            else
            {
                pressedCell = ChooseCell(playerTwoCombinationArray);
            }
            return pressedCell;
        }

        public int Defends()
        {
            int pressedCell;
            Combination[] playerOneCombinationArray = FindTwoCellPlayer(1);
            if (playerOneCombinationArray.Length == 0)
            {
                List<int> cellList = new List<int>();
                int[] cellArray = new int[4] { 2, 4, 6, 8 };
                for (int i = 0; i < 4; i++)
                {
                    if(IsCellAvailable(cellArray[i]))
                    {
                        cellList.Add(cellArray[i]);
                    }
                }
                cellArray = cellList.ToArray();
                pressedCell = cellArray.Length > 0 ? ExtractRandomCell(cellArray) : GetEmptyCell(); 
            } else
            {
                pressedCell = ChooseCell(playerOneCombinationArray);
            }
            return pressedCell;
        }

        public Combination[] FindTwoCellPlayer(int player)
        {
            int otherPlayer = player == 1 ? 2 : 1;
            List<Combination> combinationsList = new List<Combination>();
            foreach (Combination combinationItem in this.WinningCombinations.CombinationsArray)
            {
                int cellCounter = 0;
                int otherCellCounter = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (combinationItem.CombinationArray[i] == player)
                    {
                        cellCounter++;
                    } else if (combinationItem.CombinationArray[i] == otherPlayer)
                    {
                        otherCellCounter++;
                    }
                }
                if (cellCounter == 2 && otherCellCounter == 0)
                {
                    combinationsList.Add(combinationItem);
                }
            }

            Combination[] combinationsArray = combinationsList.ToArray();
            return combinationsArray;
        }

        public bool IsCellAvailable(int cellNumber)
        {
            string targetCell = cellNumber.ToString();
            foreach (Combination combinationItem in this.WinningCombinations.CombinationsArray)
            {
                if (combinationItem.Name.Contains(targetCell))
                {
                    for (int charCounter = 0; charCounter < 3; charCounter++)
                    {
                        if (targetCell.Equals(combinationItem.Name[charCounter].ToString()))
                        {
                            if (combinationItem.CombinationArray[charCounter] > 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public int ChooseCell(Combination[] combinationsArray)
        {
            bool isCombinationAvailable = false;
            int[] counterArray = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < combinationsArray.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (combinationsArray[i].CombinationArray[j] == 0)
                    {
                        int counterIndex = Int32.Parse(combinationsArray[i].Name[j].ToString()) - 1;
                        counterArray[counterIndex]++;
                        isCombinationAvailable = true;
                    }
                }
            }
            if (isCombinationAvailable)
            {
                int maxValue = counterArray.Max();
                int maxIndex = counterArray.ToList().IndexOf(maxValue);
                int selectedCell = maxIndex + 1;
                return selectedCell;
            } else
            {
                return GetEmptyCell();
            }
            
        }

        public int GetEmptyCell()
        {
           for (int cellNumber = 1; cellNumber <= 9; cellNumber++)
            {
                if(IsCellAvailable(cellNumber))
                {
                    return cellNumber;
                }
            }
            return 0;
        }

    }
}
