using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipage
{
    class Mecanicien : Equipage
    {
        public Mecanicien() : base() { }

        public void Capacite(Vaisseau vaisseau)
        {
            if (vaisseau.HP < 10 && vaisseau.HP >0)
            vaisseau.HP += 1;
        }

        public override string ToString()
        {
            return string.Format("Le mecanicien a {0} point de vie, il possède {1} dés et se trouve dans la salle : {2}.", this.HP, this.Dices, this.Room);
        }
    }
}
