using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class TransactionInfo
    {
        public XmlNode FromNode;
        public string Vid { get; set; }
        public string Type { get; set; }
        public string AccountPayer { get; set; }
        public string ESPLIdentity { get; set; }
        public string AccountReciever { get; set; }
        public AuthorizationInfo AuthorizationInfo { get; set; }

        public TransactionInfo(XmlNode node)
        {
            FromNode = node;
            foreach(XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("ВидПереводДС"):
                        Vid = childNode.InnerText;
                        break;
                    case ("ТипОператорДС"):
                        Type = childNode.InnerText;
                        break;
                    case ("НомерСчетПлательщик"):
                        AccountPayer = childNode.InnerText;
                        break;
                    case ("ИдентЭСППлательщик"):
                        ESPLIdentity = childNode.InnerText;
                        break;
                    case ("НомерСчетПолучатель"):
                        AccountReciever = childNode.InnerText;
                        break;
                    case ("СведАвторизацияЭСП"):
                        AuthorizationInfo = new AuthorizationInfo(childNode);
                        break;
                }
            }
        }
    }
}
