using System;
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
        // gere le deroulement general du jeu
        public static void game(int numSemaine,  List<Membre> equipage, Appareil vaisseau)
        { 
            XmlReader reader = XmlReader.Instance();
            // Salle qui va se voir attribuer la panne
            int salle;
            // Récuperation de la liste des pannes de la semaine en cours
            List<int> listPannes = reader.getPanne(numSemaine);
            // Génère les pannes requises
            if (listPannes[0] > 0)
            {
                for(int i = 0; i < listPannes[0]; i++)
                {
                    salle = Membre.RandomNumber(1, 7);
                    vaisseau.Rooms[salle-1].Panne += Membre.RandomNumber(1, 11);
                }
            }
            if (listPannes[1] > 0)
            {
                for (int i = 0; i < listPannes[1]; i++)
                {
                    salle = Membre.RandomNumber(1, 7);
                    vaisseau.Rooms[salle-1].Panne += Membre.RandomNumber(12, 23);
                }
            }
            if (listPannes[2] > 0)
            {
                for (int i = 0; i < listPannes[2]; i++)
                {
                    salle = Membre.RandomNumber(1, 7);
                    vaisseau.Rooms[salle-1].Panne += Membre.RandomNumber(24,35);
                }
            }

        }  
    }
}
