using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model.ChildNodes
{
    public class BankInfo
    {
        public XmlNode FromNode;
        public string RegNumber { get; set; }
        public string BIKKO { get; set; }
        public string OKATO { get; set; }
        public BankInfo(XmlNode node)
        {
            FromNode = node;    
            foreach(XmlNode element in node.ChildNodes)
            {
                switch (element.Name)
                {
                    case ("РегНомКО"):
                        RegNumber = element.InnerText;
                        break;
                    case ("БИККО"):
                        BIKKO = element.InnerText;
                        break;
                    case ("ОКАТОКО"):
                        OKATO = element.InnerText;
                        break;
                }
            }
        }
    }
}
