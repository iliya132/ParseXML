using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model.ChildNodes
{
    public class FilialInfo
    {
        public XmlNode FromNode;
        public string RegNumber { get; set; }
        public string FilialNumber { get; set; }
        public string BIK { get; set; }
        public string OKATO { get; set; }

        public FilialInfo(XmlNode node)
        {
            FromNode = node;
            foreach(XmlNode elem in node.ChildNodes)
            {
                switch (elem.Name)
                {
                    case ("РегНомКО"):
                        RegNumber = elem.InnerText;
                        break;
                    case ("НомФл"):
                        FilialNumber = elem.InnerText;
                        break;
                    case ("БИКФл"):
                        BIK = elem.InnerText;
                        break;
                    case ("ОКАТОФл"):
                        OKATO = elem.InnerText;
                        break;
                }
            }
        }

    }
}
