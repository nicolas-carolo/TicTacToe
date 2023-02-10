using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Entities
{
    public class BotPlayer
    {

        internal int StartingPlayer;
        internal int PressedCells;
        internal WinningCombinations WinningCombinations = new WinningCombinations();

        public BotPlayer(int lastPlayer)
        {
            if (lastPlayer == 1)
            {
                this.StartingPlayer = 2;
            }
            else
            {
                this.StartingPlayer = 1;
            }
            this.PressedCells = 0;
        }

        public int PressCell()
        {
            int pressedCell;
            if ((this.StartingPlayer == 2) || (this.PressedCells == 1 && this.StartingPlayer == 1 && !(IsCellAvailable(5))))
            {
                Console.WriteLine("Attack");
                pressedCell = Attacks();
            }
            else if (this.PressedCells == 1 && this.StartingPlayer == 1 && IsCellAvailable(5))
            {
                pressedCell = 5;
            }
            else
            {
                Console.WriteLine("Defend");
                pressedCell = Defends();
            }
            return pressedCell;
        }

        public void Update(WinningCombinations winningCombinations, int pressedCells)
        {
            this.WinningCombinations = winningCombinations;
            this.PressedCells = pressedCells;
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
                    if (cellArray.Length > 0)
                    {
                        pressedCell = ExtractRandomCell(cellArray);
                    }
                    else
                    {
                        pressedCell = GetEmptyCell();
                    }
                } else
                {
                    pressedCell = ChooseCell(playerOneCombinationArray);
                }
            }
            else
            {
                pressedCell = ChooseCell(playerTwoCombinationArray);
                Console.WriteLine("Selected Attack cell: " + pressedCell.ToString());
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
                if (cellArray.Length > 0)
                {
                    pressedCell = ExtractRandomCell(cellArray);
                } else
                {
                    pressedCell = GetEmptyCell();
                }
                
            } else
            {
                pressedCell = ChooseCell(playerOneCombinationArray);
                //Console.WriteLine("Selected: " + pressedCell.ToString());
            }
            return pressedCell;
        }

        public Combination[] FindTwoCellPlayer(int player)
        {
            int otherPlayer;
            if (player == 1)
            {
                otherPlayer = 2;
            } else
            {
                otherPlayer = 1;
            }
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
