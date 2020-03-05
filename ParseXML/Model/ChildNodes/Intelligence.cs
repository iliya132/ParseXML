using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ParseXML.Model.ChildNodes.Operation;

namespace ParseXML.Model.ChildNodes
{
    public class Intelligence
    {
        public XmlNode FromNode;
        public string InfoGiveMarker { get; set; }
        public FilialInfo FilialInfo { get; set; }
        private List<OperationClass> _operations = new List<OperationClass>();
        public List<OperationClass> Operations { get => _operations; set => _operations = value; }

        public Intelligence(XmlNode node)
        {
            FromNode = node;
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("ПризнакПредставСвед"):
                        InfoGiveMarker = childNode.InnerText;
                        break;
                    case ("ИнфФилиал"):
                        FilialInfo = new FilialInfo(childNode);
                        break;
                    case ("Операция"):
                        Operations.Add(new OperationClass(childNode));
                        break;
                }
            }

        }
    }
}
