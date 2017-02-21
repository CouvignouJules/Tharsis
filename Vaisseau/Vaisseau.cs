using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaisseau
{
    class Vaisseau
    {
        private int hp;
        public int Hp
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value;
            }
        }

        List<Room> Rooms = new List<Room>();
        Random rnd = new Random();

        public Vaisseau()
        {
            generateHp();
            Rooms.Add(new Room(1, "Pilotage", 0));
            Rooms.Add(new Room(2, "Serre", 0));
            Rooms.Add(new Room(3, "Infirmerie", 0));
            Rooms.Add(new Room(4, "Laboratoire", 0));
            Rooms.Add(new Room(5, "Détente", 0));
            Rooms.Add(new Room(6, "Survie", 0));
            Rooms.Add(new Room(7, "Maintenance", 0));
        }

        public void generateHp()
        {
            this.hp = rnd.Next(2, 6);
        }



        public override string ToString()
        {
            return string.Format("le vaisseau a {0} PV",this.Hp);
        }
    }
}
