using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipage
{
    class Commandant : Equipage
    {
        public Commandant() : base() { }

        public void Capacite(Vaisseau vaisseau)
        {
            foreach(Vaisseau room in vaisseau.ListRooms)
            {
                if (room.Name == this.Room)
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
