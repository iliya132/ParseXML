using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class ParticipantUL
    {
        public XmlNode FromNode;
        public ULInfo ULInfo { get; set; }
        public EIOInfo EIOInfo { get; set; }

        public ParticipantUL(XmlNode node)
        {
            FromNode = node;
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("СведЮЛ"):
                        ULInfo = new ULInfo(childNode);
                        break;
                    case ("СведФЛИП"):
                    case ("СведЕИО"):
                        EIOInfo = new EIOInfo(childNode);
                        break;
                }
            }
        }
    }
}
