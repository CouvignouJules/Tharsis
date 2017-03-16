using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class Roll
    {
        private static Random _random = new Random(); // une seule instance !

        // Lance les dés
        public static List<int> RollTheDices(int numberOfDice, int numberOfSides)
        {
            if (numberOfDice <= 0)
            {
                throw new Exception("Le nombre de dés doit être supérieur à zéro.");
            }

            if (numberOfSides <= 0)
            {
                throw new Exception("Le nombre de dés doit être supérieur à zéro.");
            }

            List<int> roll = new List<int>();

            for (int i = 0; i < numberOfDice; i++)
            {
                roll.Add(_random.Next(1, numberOfSides + 1));
            }

            return roll;
        }
    }
}
