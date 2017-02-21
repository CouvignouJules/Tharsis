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
                if (membre.Dices < 6)
                {
                    membre.Dices = membre.Dices + 1;
                }  
            }
        }

        public override string ToString()
        {
            return string.Format("Le medecin a {0} point de vie, il possède {1} dés et se trouve dans la salle : {2}.", this.HP, this.Dices, this.Room);
        }
    }
}
