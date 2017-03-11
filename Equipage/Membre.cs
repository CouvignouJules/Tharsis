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

        private Room room;
        public string Room
        {
            get
            {
                return this.room.Nom;
            }
            set
            {
                this.room.Nom = value;
            }
        }
        Random rnd = new Random();

        public Equipage()
        {
            generateHP();
            generateDices();
        }

        public void generateHP()
        {
           this.hp = rnd.Next(2, 4);
        }

        public void generateDices()
        {
            this.dices = rnd.Next(2, 4);
        }

        public abstract override string ToString();
    }
}
