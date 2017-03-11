using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class Dice
    {
        private static Random _random = new Random(); // une seule instance !

        public static string Roll(int numberOfDice, int numberOfSides)
        {
            if (numberOfDice <= 0)
            {
                throw new Exception("Number of dices must be greater than zero.");
            }

            if (numberOfSides <= 0)
            {
                throw new Exception("Number of sides must be greater than zero.");
            }

            int[] roll = new int[numberOfDice];

            for (int i = 0; i < numberOfDice; i++)
            {
                roll[i] = _random.Next(1, numberOfSides + 1);
            }

            StringBuilder result = new StringBuilder();
            int total = 0;

            for (int i = 0; i < roll.Length; i++)
            {
                total += roll[i];
                result.AppendFormat("Dice {0:00}:\t{1}\n", i + 1, roll[i]);
            }

            result.AppendFormat("\t\t--\n");
            result.AppendFormat("TOTAL:\t\t{0}", total);

            return result.ToString();
        }
    }
}
