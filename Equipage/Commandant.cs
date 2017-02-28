using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaisseau;

namespace Equipage
{
    class Commandant : Equipage
    {
        public Commandant() : base() { }

        public void Capacite(Vaisseau.Vaisseau vaisseau)
        {
            foreach(Vaisseau.Room room in vaisseau.Rooms)
            {
                if (room.Nom == this.Room)
                {
                    room.Panne -= 10;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Le commandant a {0} point de vie, il possède {1} dés et se trouve dans la salle : {2}.", this.HP, this.Dices, this.Room);
        }
    }
}
