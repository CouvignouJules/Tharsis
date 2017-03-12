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

        public override void Capacite(Appareille vaisseau, List<Membre> equipage)
        {
            foreach (Membre membre in equipage)
            {
                if (membre.HP < 6 && membre.HP > 0)
                    membre.HP += 1;
            }
        }

        public override string info(Appareille appareille)
        {
            return String.Format("Le médecin a {0} points de vie, il possède {1} dés et se trouve dans la salle : {2}.", this.HP, this.Dices, appareille.getRommName(this.Room));
        }
    }
}
