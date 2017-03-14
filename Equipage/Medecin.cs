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

        public override void Capacite(Appareil vaisseau, List<Membre> equipage)
        {
            foreach (Membre membre in equipage)
            {
                if (membre.HP < 6 && membre.HP > 0)
                    membre.HP += 1;
            }
        }

        public override string info(Appareil vaisseau)
        {
            return string.Format("Hp: {0} \nDice: {1} \nsalle: {2} \n", this.HP, this.Dices, vaisseau.getRommName(this.Room));
        }
    }
}
