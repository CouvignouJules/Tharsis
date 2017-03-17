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
        // Les points de vie de chaque membre d'équipage
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

        // Le nombre de dés de chaque membre d'équipage
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

        // Les dés de chaque membre d'équipage
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

        // Les dés déjà utilisés de chaque membre d'équipage
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

        // Nombre de fois qu'il est possible d'activer la capacité par tour
        private int capaciteNumber;
        public int CapaciteNumber
        {
            get
            {
                return capaciteNumber;
            }
            set
            {
                this.capaciteNumber = value;
            }
        }

        // La salle dans laquelle chaque membre d'équipage se trouve (catégorisée par un nombre)
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

        // Nombre de fois qu'il est possible de relancer les dés sélectionnés
        private int validateReroll;
        public int ValidateReroll
        {
            get
            {
                return validateReroll;
            }

            set
            {
                validateReroll = value;
            }
        }

        // ctor
        public Membre()
        {
            GenerateHP();
            GenerateDices();
            GiveRoom();
            validateReroll = 0;
            capaciteNumber = 0;
        }

        // Le nombre de PV de départ du membre
        public void GenerateHP()
        {
           this.hp = RandomNumber(2, 4);
        }

        // Le nombre de dés de départ du membre
        public void GenerateDices()
        {
            this.dices = RandomNumber(2, 4);
        }

        // La salle de départ du membre
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

        // La capacité du membre d'équipage
        public abstract void Capacite(Appareil vaisseau, List<Membre> equipage);

        // Les informations du membre d'équipage (nombre de PV, de dés et salle actuelle)
        public abstract string Info(Appareil vaisseau);
    }
}
