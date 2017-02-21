using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipage
{
    abstract class Equipage
    {
        int pv;
        int des;
        Random rnd = new Random();
        public int pif()
        {
            return rnd.Next(2,4);
        }

        public abstract void toString(in truc);
    }
}
