using ParseXML.Model.ChildNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model
{
    public class XmlModel
    {
        public ServicePart ServicePart { get; set; }
        public InfoPart InfoPart { get; set; }

        public XmlModel(XmlNode node)
        {
            foreach (XmlElement element in node.ChildNodes)
            {
                if (element.Name.Equals("СлужЧасть")) // служебная часть
                {
                    ServicePart = new ServicePart(element);
                }
                else if (element.Name.Equals("ИнформЧасть"))
                {
                    InfoPart = new InfoPart(element);
                }
            }
        }

    }
}
