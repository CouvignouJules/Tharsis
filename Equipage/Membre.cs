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
        private List<int> myDice = new List<int>();
        public List<int> MyDice
        {
            get
            {
                return myDice;
            }
            set
            {
                this.myDice = value;
            }
        }
        private List<int> usedDice = new List<int>();
        public List<int> UsedDice
        {
            get
            {
                return usedDice;
            }
            set
            {
                this.usedDice = value;
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

        public Membre()
        {
            GenerateHP();
            GenerateDices();
            GiveRoom();
        }

        public void GenerateHP()
        {
           this.hp = RandomNumber(2, 4);
        }

        public void GenerateDices()
        {
            this.dices = RandomNumber(2, 4);
        }

        public void GiveRoom()
        {
            this.room = RandomNumber(1, 7);
        }

        private static readonly Random rdm = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return rdm.Next(min, max);
            }
        }

        public abstract void Capacite(Appareil vaisseau, List<Membre> equipage);
        public abstract string Info(Appareil vaisseau);
    }
}
