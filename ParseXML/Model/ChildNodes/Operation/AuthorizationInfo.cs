using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class AuthorizationInfo
    {
        public XmlNode FromNode;
        public string TerminalId { get; set; }
        public TransactionPlace TransactionPlace { get; set; }
        public AuthorizationInfo(XmlNode node)
        {
            FromNode = node;
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("ИдТерминал"):
                        TerminalId = childNode.InnerText;
                        break;
                    case ("АдрМестаПриемаВыдача"):
                        TransactionPlace = new TransactionPlace(childNode);
                        break;
                }
            }
        }
    }
}