using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipage
{
    abstract class Equipage
    {
        protected int pv;
        protected int dice;
        Random rnd = new Random();

        public Equipage()
        {
            pv = pif();
            dice = pif();
        }

        public int pif()
        {
            return rnd.Next(2,4);
        }

        public int getPv()
        {
            return pv;
        }
        public void setPv(int pv)
        {
            this.pv = pv;
        }
        public int getDice()
        {
            return dice;
        }
        public void setDice(int dice)
        {
            this.dice = dice;
        }

        public abstract void ToString();
    }
}
