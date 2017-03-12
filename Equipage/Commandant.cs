using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaisseau;

namespace Equipage
{
    public class Commandant : Membre
    {
        public Commandant() : base() { }

        public override void Capacite(Appareil vaisseau, List<Membre> equipage)
        {
            foreach(Room room in vaisseau.Rooms)
            {
                if (room.Numero == this.Room)
                    room.Panne -= 10;
            }
        }

        public override string info(Appareil vaisseau)
        {
            return string.Format("Le commandant a {0} point de vie, il possède {1} dés et se trouve dans la salle : {2}.", this.HP, this.Dices, vaisseau.getRommName(this.Room));
        }
    }
}
