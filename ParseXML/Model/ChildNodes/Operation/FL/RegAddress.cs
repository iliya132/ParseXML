using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class RegAddress
    {
        public string Index { get; set; }
        public string OKSMCode { get; set; }
        public string CountryName { get; set; }
        public string OKATOSubjectName { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string HouseBuilding { get; set; }
        public string Office { get; set; }
        public RegAddress(XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("Индекс"):
                        Index = childNode.InnerText;
                        break;
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
                    case ("Улица"):
                        Street = childNode.InnerText;
                        break;
                    case ("Дом"):
                        House = childNode.InnerText;
                        break;
                    case ("Корп"):
                        HouseBuilding = childNode.InnerText;
                        break;
                    case ("Оф"):
                        Office = childNode.InnerText;
                        break;
                }
            }
        }
    }
}