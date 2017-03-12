﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dice;
using Equipage;
using Vaisseau;

namespace Tharsis
{
    public class Tour
    {
        int numSemaine = 1;
        List<Membre> equipage = new List<Membre>();
        Appareil vaisseau = new Appareil();
        // gere le deroulement general du jeu
        public void game()
        { 
            InitEquipage();
            XmlReader reader = XmlReader.Instance();

            while (numSemaine < 10)
            {
                //recuperation de la liste des pannes de la semaine en cours
                List<int> listPannes = reader.getPanne(numSemaine);
                //genere les pannes requises
                if (listPannes[0] > 0)
                {
                    for(int i = 0; i <= listPannes[0]; i++)
                    {
                        MakePetitePanne();
                    }
                }
                if (listPannes[1] > 0)
                {
                    for (int i = 0; i <= listPannes[1]; i++)
                    {
                        MakeMoyennePanne();
                    }
                }
                if (listPannes[2] > 0)
                {
                    for (int i = 0; i <= listPannes[2]; i++)
                    {
                        MakeGrossePanne();
                    }
                }


            }
        }

        //genere la liste des membres d'equipage
        public void InitEquipage()
        {
            equipage.Add(new Capitaine());
            equipage.Add(new Commandant());
            equipage.Add(new Mecanicien());
            equipage.Add(new Medecin());
        }

        //affecte à une salle au hasard la valeur d'une petite panne
        public void MakeGrossePanne()
        {

        }
        //affecte a une salle au hasard la valeur d'une moyenne panne
        public void MakeMoyennePanne()
        {

        }
        //affecte a une salle au hasard la valeur d'une grosse panne
        public void MakePetitePanne()
        {

        }
        //decrit le tour de capitaine
        public void TourCapitaine()
        {

        }
        //decrit le tour de commandant
        public void TourCommandant()
        {

        }
        //decrit le tour du mecanicien
        public void TourMecanicien()
        {

        }
        //decrit le tour du medecin
        public void TourMedecin()
        {

        }
    }
}
