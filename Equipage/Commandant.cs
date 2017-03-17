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

        // Réduit le montant des pannes de la salle dans laquelle le commandant se situe de 10 points
        public override void Capacite(Appareil vaisseau, List<Membre> equipage)
        {
            foreach(Room room in vaisseau.Rooms)
            {
                if (room.Numero == this.Room && room.Panne > 0)
                {
                    room.Panne -= 10;
                    if (room.Panne < 0)
                        room.Panne = 0;
                }
            }
        }

        public override string Info(Appareil vaisseau)
        {
            return string.Format("PV: {0} \nDés: {1} \nSalle: {2} \n", this.HP, this.Dices, vaisseau.getRommName(this.Room));
        }
    }
}
