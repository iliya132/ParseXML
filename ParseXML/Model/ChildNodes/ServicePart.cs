using ParseXML.Model.ChildNodes;
using System;
using System.Xml;

namespace ParseXML.Model
{
    public class ServicePart
    {
        public XmlNode FromNode;
        public string Version { get; set; }
        public string ProgramVersion { get; set; }
        public string CorId { get; set; }
        public string InfoType { get; set; }
        private DateTime messageData;
        public DateTime MessageDate { get => messageData; set => messageData = value; }
        public string AuthorizedUserPosition { get; set; }
        public AuthorizedUserFIO Fio { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ServicePart(XmlNode node)
        {
            FromNode = node;
            foreach (XmlNode elem in node.ChildNodes)
            {
                string innerText = elem.InnerText;

                switch (elem.Name)
                {
                    case ("ВерсияФормата"):
                        Version = innerText;
                        break;
                    case ("ВерсПрог"):
                        ProgramVersion = innerText;
                        break;
                    case ("ИДКорр"):
                        CorId = innerText;
                        break;
                    case ("ТипИнф"):
                        InfoType = innerText;
                        break;
                    case ("ДатаСообщения"):
                        DateTime.TryParse(innerText, out messageData);
                        break;
                    case ("УполнСотрудн"):
                        AuthorizedUserPosition = innerText;
                        break;
                    case ("ФИОУполнСотрудн"):
                        Fio = new AuthorizedUserFIO(elem);
                        break;
                    case ("ТелУполнСотрудн"):
                        PhoneNumber = innerText;
                        break;
                    case ("ЭлектроннаяПочта"):
                        Email = innerText;
                        break;
                }
            }
        }
    }
}
