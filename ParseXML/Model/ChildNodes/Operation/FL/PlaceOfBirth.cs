using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class PlaceOfBirth
    {
        public string OKSMCode { get; set; }
        public string CountryName { get; set; }
        public string OKATOSubjectName { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public PlaceOfBirth(XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("КодОКСМ"):
                        OKSMCode = childNode.InnerText;
                        break;
                    case ("СтранаНаименование"):
                        CountryName = childNode.InnerText;
                        break;
                    case ("КодСубъектаПоОКАТО"):
                        OKATOSubjectName = childNode.InnerText;
                        break;
                    case ("Район"):
                        Area = childNode.InnerText;
                        break;
                    case ("Пункт"):
                        City = childNode.InnerText;
                        break;
                }
            }
        }
    }
}