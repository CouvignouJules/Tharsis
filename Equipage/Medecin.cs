using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaisseau;
namespace Equipage
{
    public class Medecin : Membre
    {
        public Medecin() : base() { }

        // Redonne 1 PV à tous les membres d'équipage à condition que ceux-ci soient vivants
        public override void Capacite(Appareil vaisseau, List<Membre> equipage)
        {
            foreach (Membre membre in equipage)
            {
                if (membre.HP < 6 && membre.HP > 0 && membre.IsDead == false)
                    membre.HP += 1;
            }
        }

        public override string Info(Appareil vaisseau)
        {
            return string.Format("PV: {0} \nDés: {1} \nSalle: {2} \n", this.HP, this.Dices, vaisseau.getRommName(this.Room));
        }
    }
}
