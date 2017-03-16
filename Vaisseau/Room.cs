using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaisseau
{
    public class Room
    {
        // Numéro d'identification des salles
        private int numero;
        public int Numero
        {
            get
            {
                return numero;
            }
        }

        // Numéro d'identification des pannes
        private int panne;
        public int Panne
        {
            get
            {
                return panne;
            }

            set
            {
                panne = value;
            }
        }

        // Nom des salles
        private string nom;
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                nom = value;
            }
        }

        // ctor
        public Room(int num, string nom, int panne)
        {
            this.numero = num;
            this.nom = nom;
            this.panne = panne;
        }

        // Affiche l'état de la salle
        public override string ToString()
        {
            return string.Format("le montant de panne de la salle {0} est de {1}",this.Nom,this.Panne);
        }

    }
}
