using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class ULInfo
    {
        public XmlNode FromNode;
        public string Name { get; set; }
        public string FLMarker { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string OGRN { get; set; }
        public AddressUL AddressRegUL { get; set; }
        public AddressUL AddressUL { get; set; }
        private DateTime _regDate;
        public DateTime RegDate { get => _regDate; set => _regDate = value; }
        
        public ULInfo(XmlNode node)
        {
            FromNode = node;
            foreach(XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("НаимЮЛ"):
                        Name = childNode.InnerText;
                        break;
                    case ("ПризнакФлЮЛ"):
                        FLMarker = childNode.InnerText;
                        break;
                    case ("ИННЮЛ"):
                        INN = childNode.InnerText;
                        break;
                    case ("КППЮЛ"):
                        KPP = childNode.InnerText;
                        break;
                    case ("ОГРНЮЛ"):
                        OGRN = childNode.InnerText;
                        break;
                    case ("АдрРегЮЛ"):
                        AddressRegUL = new AddressUL(childNode);
                        break;
                    case ("ДатаРегЮЛ"):
                        DateTime.TryParse(childNode.InnerText, out _regDate);
                        break;
                    case ("АдрЮЛ"):
                        AddressUL = new AddressUL(childNode);
                        break;

                }
            }
        }
    }
}
