using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipage
{
    class Capitaine : Equipage
    {
        public Capitaine() : base() { }

        public void Capacite(List<Equipage> list)
        {
            foreach (Equipage membre in list)
            {
                if (membre.getDice() < 6)
                {
                    membre.setDice(membre.getDice() + 1);
                }
                
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
