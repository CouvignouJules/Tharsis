using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaisseau;

namespace Equipage
{
    abstract public class Membre
    {
        private int hp;
        public int HP
        {
            set
            {
                this.hp = value;
            }
            get
            {
                return this.hp;
            }
        }

        private int dices;
        public int Dices
        {
            get
            {
                return this.dices;
            }
            set
            {
                this.dices = value;
            }
        }

        private int room;
        public int Room
        {
            get
            {
                return this.room;
            }
            set
            {
                this.room = value;
            }
        }
        Random rnd = new Random();

        public Membre()
        {
            generateHP();
            generateDices();
            giveRoom();
        }

        public void generateHP()
        {
           this.hp = rnd.Next(2, 4);
        }

        public void generateDices()
        {
            this.dices = rnd.Next(2, 4);
        }

        public void giveRoom()
        {
            this.room = rnd.Next(1, 7);
        }

        public abstract void Capacite(Appareil vaisseau, List<Membre> equipage);
        public abstract string info(Appareil vaisseau);
    }
}
