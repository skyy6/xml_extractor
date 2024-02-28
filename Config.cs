using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_extractor
{
    class Config
    {
        public static XmlDocument doc = null;
        public static void LoadXML()
        {

            XmlDocument configdoc = new XmlDocument();
            try
            {
                configdoc.Load("C:\\XML_Extractor\\Config.xml"); //måste peka ut manuellt var man ska kolla i dagsläget
            }
            catch
            {
                Console.WriteLine("Kan ej hitta configfil");
            }
            doc = configdoc;
        }

        public static string Setting(string name)
        {
            string setting = "";

            XmlNode x = doc.SelectSingleNode("//settings/" + name);

            if(x != null)
            {
                setting = x.InnerText;
                return setting;
            }
            else
            {
                return setting;
            }
        }
       
    }
}
