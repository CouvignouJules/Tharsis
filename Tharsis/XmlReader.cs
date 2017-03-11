using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Tharsis
{
    class XmlReader
    {
        private static XmlReader _instance;
        IEnumerable<XElement> pannes;
        List<int> semaine = new List<int>();

        protected XmlReader()
        {
            XElement doc = XElement.Load("..\\..\\Scenario.xml");
            pannes = doc.Elements();
        }

        public static XmlReader Instance()
        {
            if (_instance == null)
            {
                _instance = new XmlReader();
            }

            return _instance;
        }
        public List<int> getPanne(int numSemaine)
        {
            foreach (var p in pannes)
            {
                if (Int32.Parse(p.Element("numero").Value) == numSemaine)
                {
                    semaine.Add(Int32.Parse(p.Element("petite").Value));
                    semaine.Add(Int32.Parse(p.Element("moyenne").Value));
                    semaine.Add(Int32.Parse(p.Element("grosse").Value));
                }
            }
            return semaine;
        }
    }
}