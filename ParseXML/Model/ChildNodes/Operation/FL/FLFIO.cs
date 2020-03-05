using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class FLFIO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public FLFIO(XmlNode node)
        {
            foreach(XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("Фам"):
                        FirstName = childNode.InnerText;
                        break;
                    case ("Имя"):
                        LastName = childNode.InnerText;
                        break;
                    case ("Отч"):
                        Patronymic = childNode.InnerText;
                        break;
                }
            }
        }
    }
}