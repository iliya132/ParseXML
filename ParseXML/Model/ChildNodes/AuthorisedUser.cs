using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model.ChildNodes
{
    public class AuthorizedUserFIO
    {
        public XmlNode FromNode;
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public AuthorizedUserFIO(XmlNode node)
        {
            FromNode = node;    
            foreach(XmlNode element in node.ChildNodes)
            {
                switch (element.Name)
                {
                    case ("Фам"):
                        LastName = element.InnerText;
                        break;
                    case ("Имя"):
                        FirstName = element.InnerText;
                        break;
                    case ("Отч"):
                        Patronymic = element.InnerText;
                        break;
                }
            }
        }
    }
}
