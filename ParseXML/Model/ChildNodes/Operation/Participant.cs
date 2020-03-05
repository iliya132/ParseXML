using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class Participant
    {
        public XmlNode FromNode;
        public string Status { get; set; }
        public string ParticipantType { get; set; }
        public string ParticipantMarker { get; set; }
        public string ClientMarker { get; set; }
        public ParticipantUL UL { get; set; }
        public string ParticipantComment { get; set; }
        public Participant(XmlNode node)
        {
            FromNode = node;
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("СтатусУчастника"):
                        Status = childNode.InnerText;
                        break;
                    case ("ТипУчастника"):
                        ParticipantType = childNode.InnerText;
                        break;
                    case ("ПризнУчастника"):
                        ParticipantMarker = childNode.InnerText;
                        break;
                    case ("ПризнКлиент"):
                        ClientMarker = childNode.InnerText;
                        break;
                    case ("УчастникФЛИП"):
                    case ("УчастникЮЛ"):
                        UL = new ParticipantUL(childNode);
                        break;
                    case ("КомментУчастник"):
                        ParticipantComment = childNode.InnerText;
                        break;
                    default:
                        Console.WriteLine(childNode.Name);
                        break;
                }
            }
        }
    }
}
