using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipage
{
    class Medecin : Equipage
    {
        public Medecin() : base() { }

        public void Capacite(List<Equipage> list)
        {
            foreach ( Equipage membre in list)
            {
                membre.setPv(membre.getPv() + 1);
            }
        }

        public override string ToString()
        {
            return "Le medecin a {0} point de vie et l possede {1} dés";
        }
    }
}
