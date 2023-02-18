using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class WinningCombinations
    {

        public Combination[] CombinationsArray = new Combination[8];


        public WinningCombinations() {
            this.CombinationsArray[0] = new Combination("123");
            this.CombinationsArray[1] = new Combination("147");
            this.CombinationsArray[4] = new Combination("456");
            this.CombinationsArray[2] = new Combination("789");
            this.CombinationsArray[3] = new Combination("258");
            this.CombinationsArray[5] = new Combination("369");
            this.CombinationsArray[6] = new Combination("159");
            this.CombinationsArray[7] = new Combination("357");
        }

        public int IsWinner()
        {
            foreach (Combination combinationItem in this.CombinationsArray)
            {
                int winner = combinationItem.AreAllEqual();
                if (winner > 0)
                {
                    return winner;
                }
            }
            return 0;
        }

        public void UpdateCombinations(int cellNumber, int lastPlayer)
        {
            string pressedCell = cellNumber.ToString();
            foreach(Combination combinationItem in this.CombinationsArray)
            {
                if (combinationItem.Name.Contains(pressedCell))
                {
                    int charCounter = 0;
                    foreach (char charName in combinationItem.Name)
                    {
                        if (pressedCell.Equals(charName.ToString()))
                        {
                            combinationItem.CombinationArray[charCounter] = lastPlayer;
                        }
                        charCounter++;
                    }
                }
                Console.WriteLine(combinationItem.Name + ": " + combinationItem.CombinationArray[0] + " " + combinationItem.CombinationArray[1] + " " + combinationItem.CombinationArray[2]);
            }
        }
    }
}
