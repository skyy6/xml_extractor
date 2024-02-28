using System;
using System.Xml;

namespace XML_extractor
{
    class Job
    {
        static void Main(string[] args)
        {

            //Ladda configfilen
            Config.LoadXML();


            string inputFilePath = Config.Setting("FileInputDirectory");
            string outputFilePath = Config.Setting("FileOutputDirectory");

            string elementName = Config.Setting("ParentName");
            string nameOfNode = Config.Setting("ChildName");



            XmlDocument inputXMLdoc = new XmlDocument();
            inputXMLdoc.Load(inputFilePath);


            XmlDocument outputXMLdoc = new XmlDocument();

            //Rotelement som används för att mappa in önskade element nedan
            XmlElement outputRoot = outputXMLdoc.CreateElement("Root");
            outputXMLdoc.AppendChild(outputRoot);

            //Gör en nodelist med alla värden från det element som man vill gå igenom
            XmlNodeList elements = inputXMLdoc.GetElementsByTagName(elementName);

            //Loopa över alla element med vald tagg
            foreach (XmlNode element in elements)
            {

                //välj bara ut de element som har den önskade noden 
                XmlNodeList elementsToExtract = element.SelectNodes(nameOfNode);

                if (elementsToExtract.Count > 0)
                {
                    XmlNode importedNode = outputXMLdoc.ImportNode(element, true);
                    XmlNode clonedElement = importedNode.CloneNode(true);
                    outputRoot.AppendChild(clonedElement);
                }
            }


            outputXMLdoc.Save(outputFilePath);
        }
    }
}