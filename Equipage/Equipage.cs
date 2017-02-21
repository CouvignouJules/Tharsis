using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipage
{
    abstract class Equipage
    {
        private int hp;
        public int HP
        {
            set
            {
                this.HP = value;
            }
            get
            {
                return this.HP;
            }
        }
        private int dices;
        public int Dices
        {
            get
            {
                return this.dices.length;
            }
        }
        private Vaisseau room;
        public string Room
        {
            get
            {
                return this.room.Name;
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
           this.hp = rnd.Next(2,4);
        }

        public void generateDices()
        {
            this.dices = rnd.Next(2, 4);
        }

        public abstract override string ToString();
    }
}
