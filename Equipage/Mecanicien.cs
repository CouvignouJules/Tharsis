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

        public override void Capacite(Appareil vaisseau, List<Membre> equipage)
        {
            if (vaisseau.HP < 10 && vaisseau.HP > 0)
                vaisseau.HP += 1;
        }

        public override string info(Appareil vaisseau)
        {
            return string.Format("Hp: {0} \nDice: {1} \nsalle: {2} \n", this.HP, this.Dices, vaisseau.getRommName(this.Room));
        }
    }
}
