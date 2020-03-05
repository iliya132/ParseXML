using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class OperationBase
    {
        public XmlNode FromNode;
        public string DocumentCode { get; set; }
        public string DocName { get; set; }
        private DateTime docDate;
        public DateTime DocDate { get=> docDate; set=> docDate=value; }
        public string DocumentNumber { get; set; }

        public OperationBase(XmlNode node)
        {
            FromNode = node;
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("КодДок"):
                        DocumentCode = childNode.InnerText;
                        break;
                    case ("НаимДок"):
                        DocName = childNode.InnerText;
                        break;
                    case ("ДатаДок"):
                        DateTime.TryParse(childNode.InnerText, out docDate);
                        break;
                    case ("НомДок"):
                        DocumentNumber = childNode.InnerText;
                        break;
                }
            }
        }
    }
}
