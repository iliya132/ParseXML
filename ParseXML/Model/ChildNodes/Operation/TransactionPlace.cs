using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class TransactionPlace
    {
        public XmlNode FromNode;
        public string OKSM { get; set; }
        public string CountryName { get; set; }
        public string OKATOSubjectCode { get; set; }
        public string City { get; set; }
        public TransactionPlace(XmlNode node)
        {
            FromNode = node;
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("КодОКСМ"):
                        OKSM = childNode.InnerText;
                        break;
                    case ("СтранаНаименование"):
                        CountryName = childNode.InnerText;
                        break;
                    case ("КодСубъектаПоОКАТО"):
                        OKATOSubjectCode = childNode.InnerText;
                        break;
                    case ("Пункт"):
                        City = childNode.InnerText;
                        break;
                }
            }
        }
    }
}