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

        // Redonne 1 dé à tous les membres d'équipage
        public override void Capacite(Appareil vaisseau, List<Membre> equipage)
        {
            foreach (Membre membre in equipage)
            {
                if (membre.Dices < 6)
                    membre.Dices = membre.Dices + 1;
            }
        }

        public override string Info(Appareil vaisseau)
        {
            return string.Format("PV: {0} \nDés: {1} \nSalle: {2} \n", this.HP, this.Dices, vaisseau.getRommName(this.Room));
        }
    }
}
