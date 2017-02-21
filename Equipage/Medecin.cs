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

        public override void ToString()
        {
            throw new NotImplementedException();
        }
    }
}
