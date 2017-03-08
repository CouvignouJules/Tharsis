using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Tharsis
{
    class XmlReader
    {
        private static XmlReader instance = null;
        private const String FileName = "Scenario.xml";
        private static XmlDocument _doc;

        private XmlReader() { }

        static XmlReader()
        {
            instance = new XmlReader();
            FillDoc();
        }

        public static XmlReader GetInstance()
        {
            return instance;
        }

        private static void FillDoc()
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(FileName);
            MemoryStream stream = new MemoryStream(byteArray);
            _doc = new XmlDocument();
            _doc.Load(stream);   
        }
    }
}