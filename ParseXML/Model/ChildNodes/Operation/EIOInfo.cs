using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class EIOInfo
    {
        public XmlNode FromNode;
        public string EIOType { get; set; }
        public string EIOMarker { get; set; }
        public EIOFL EIOFL { get; set; }
        public EIOInfo(XmlNode node)
        {
            FromNode = node;
            foreach(XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("ИдентификацияФЛ"):
                        EIOType = childNode.InnerText;
                        break;
                    case ("ПризнЕИО"):
                        EIOMarker = childNode.InnerText;
                        break;
                    case ("ФЛЕИО"):
                        EIOFL = new EIOFL(childNode);
                        break;
                    case ("СведЕИО"):
                        EIOFL = new EIOFL(childNode);
                        break;
                    case ("ФИОФЛИП"):
                        EIOFL = new EIOFL(node);
                        break;
                        
                }
            }
        }
    }
}
