using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaisseau
{
    public class Vaisseau
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

        List<Room> rooms = new List<Room>();
        public List<Room> Rooms
        {
            get
            {
                return rooms;
            }
        }

        Random rnd = new Random();

        public Vaisseau()
        {
            generateHp();
            rooms.Add(new Room(1, "Pilotage", 0));
            rooms.Add(new Room(2, "Serre", 0));
            rooms.Add(new Room(3, "Infirmerie", 0));
            rooms.Add(new Room(4, "Laboratoire", 0));
            rooms.Add(new Room(5, "Détente", 0));
            rooms.Add(new Room(6, "Survie", 0));
            rooms.Add(new Room(7, "Maintenance", 0));
        }

        public void generateHp()
        {
            hp = rnd.Next(2, 6);
        }



        public override string ToString()
        {
            return string.Format("le vaisseau a {0} PV", Hp);
        }
    }
}