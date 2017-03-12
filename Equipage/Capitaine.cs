using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaisseau;

namespace Equipage
{
    public class Capitaine : Membre
    {
        public Capitaine() : base() { }

        public override void Capacite(Appareil vaisseau, List<Membre> equipage)
        {
            foreach (Membre membre in equipage)
            {
                if (membre.Dices < 6)
                    membre.Dices = membre.Dices + 1;
            }
        }

        public override string info(Appareil vaisseau)
        {
            return string.Format("Le capitaine a {0} point de vie, il possède {1} dés et se trouve dans la salle : {2}.", this.HP, this.Dices, vaisseau.getRommName(this.Room));
        }
    }
}
