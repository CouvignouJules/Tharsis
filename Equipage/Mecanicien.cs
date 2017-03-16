using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaisseau;

namespace Equipage
{
    public class Mecanicien : Membre
    {
        public Mecanicien() : base() { }

        // Redonne 1 PV au vaisseau
        public override void Capacite(Appareil vaisseau, List<Membre> equipage)
        {
            if (vaisseau.HP < 10 && vaisseau.HP > 0)
                vaisseau.HP += 1;
        }

        public override string Info(Appareil vaisseau)
        {
            return string.Format("PV: {0} \nDés: {1} \nSalle: {2} \n", this.HP, this.Dices, vaisseau.getRommName(this.Room));
        }
    }
}
