using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Combination

    {

        public string Name;
        public int[] CombinationArray = new int[3];
        public Combination(string name) {
            this.Name = name;
            this.CombinationArray[0] = 0;
            this.CombinationArray[1] = 0;
            this.CombinationArray[2] = 0;
        }

        public int AreAllEqual()
        {
            if (this.CombinationArray[0] == this.CombinationArray[1] && this.CombinationArray[1] == this.CombinationArray[2] && this.CombinationArray[1] == this.CombinationArray[1])
            {
                return this.CombinationArray[0];
            } else
            {
                return 0;
            }
        }

    }
}
