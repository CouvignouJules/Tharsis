using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipage
{
    public class Medecin : Equipage
    {
        public Medecin() : base() { }

        public override void Capacite(Vaisseau.Vaisseau vaisseau, List<Equipage> equipage)
        {
            foreach (Equipage membre in equipage)
            {
                if (membre.HP < 6 && membre.HP > 0)
                    membre.HP += 1;
            }
        }

        public override string ToString()
        {
            return String.Format("Le médecin a {0} points de vie, il possède {1} dés et se trouve dans la salle : {2}.", this.HP, this.Dices, this.Room);
        }
    }
}
