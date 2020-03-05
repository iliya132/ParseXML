using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model.ChildNodes
{
    public class InfoPart
    {
        public XmlNode FromNode;
        public BankInfo bankInfo { get; set; }
        private List<Intelligence> _intelligences = new List<Intelligence>();
        public List<Intelligence> Intelligences { get => _intelligences; set => _intelligences = value; }
        public InfoPart(XmlNode node)
        {
            FromNode = node;
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("ИнфБанк"):
                        bankInfo = new BankInfo(childNode);
                        break;
                    case ("СведКО"):
                        Intelligences.Add(new Intelligence(childNode));
                        break;
                }
            }
        }
    }
}
