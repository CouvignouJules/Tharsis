﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaisseau
{
    public class Appareil
    {
        // Les points de vie du vaisseau
        private int hp;
        public int HP
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

        // Les salles du vaisseau
        List<Room> rooms = new List<Room>();
        public List<Room> Rooms
        {
            get
            {
                return rooms;
            }
        }

        Random rnd = new Random();

        // ctor
        public Appareil()
        {
            generateHp();
            rooms.Add(new Room(1, "Pilotage", 0));
            rooms.Add(new Room(2, "Serre", 0));
            rooms.Add(new Room(3, "Infirmerie", 0));
            rooms.Add(new Room(4, "Laboratoire", 0));
            rooms.Add(new Room(5, "Survie", 0));
            rooms.Add(new Room(6, "Détente", 0));
            rooms.Add(new Room(7, "Maintenance", 0));
        }

        // Les PV de départ du vaisseau
        public void generateHp()
        {
            hp = rnd.Next(2, 6);
        }

        // Accesseur du nom de la salle voulue
        public string getRommName(int numRomm)
        {
            return Rooms[numRomm-1].Nom;
        }

        // Affichage de l'état du vaisseau
        public override string ToString()
        {
            return string.Format("Points de vie du vaisseau : {0}", HP);
        }
    }
}