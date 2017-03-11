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

        public override void Capacite(Vaisseau.Vaisseau vaisseau, List<Equipage> equipage)
        {
            if (vaisseau.HP < 10 && vaisseau.HP > 0)
                vaisseau.HP += 1;
        }

        public override string ToString()
        {
            return string.Format("Le mécanicien a {0} point de vie, il possède {1} dés et se trouve dans la salle : {2}.", this.HP, this.Dices, this.Room);
        }
    }
}
