using System;
using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class DocumentInfo
    {
        public string DocumentType { get; set; }
        public string DocumentTypeName { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        private DateTime _givenDate;
        public DateTime GivenDate { get => _givenDate; set => _givenDate = value; }
        public string GivenBy { get; set; }
        public string KPPName { get; set; }
        public DocumentInfo(XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("ВидДокКод"):
                        DocumentType = childNode.InnerText;
                        break;
                    case ("ВидДокНаименование"):
                        DocumentTypeName = childNode.InnerText;
                        break;
                    case ("СерияДок"):
                        Series = childNode.InnerText;
                        break;
                    case ("НомДок"):
                        Number = childNode.InnerText;
                        break;
                    case ("ДатВыдачиДок"):
                        DateTime.TryParse(childNode.InnerText, out _givenDate);
                        break;
                    case ("КемВыданДок"):
                        GivenBy = childNode.InnerText;
                        break;
                    case ("КодПодр"):
                        KPPName = childNode.InnerText;
                        break;
                }
            }
        }
    }
}