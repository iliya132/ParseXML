using System;
using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class EIOFL
    {

        public FLFIO FLFIO { get; set; }
        public string INN { get; set; }
        public string DocumentType { get; set; }
        public DocumentInfo DocumentInfo { get; set; }
        private DateTime _birthDay;
        public DateTime BirthDay { get => _birthDay; set => _birthDay = value; }
        public PlaceOfBirth PlaceOfBirth { get; set; }
        public string OKSMCode { get; set; }
        public string CountryName { get; set; }
        public string PublicPersonMarker { get; set; }
        public RegAddress RegAddress { get; set; }

        public EIOFL(XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("ФИОФЛИП"):
                        FLFIO = new FLFIO(childNode);
                        break;
                    case ("ИННФЛИП"):
                        INN = childNode.InnerText;
                        break;
                    case ("ДокУдЛичн"):
                        DocumentType = childNode.InnerText;
                        break;
                    case ("СведДокУдЛичн"):
                        DocumentInfo = new DocumentInfo(childNode);
                        break;
                    case ("ДатаРождения"):
                        DateTime.TryParse(childNode.InnerText, out _birthDay);
                        break;
                    case ("МестоРожд"):
                        PlaceOfBirth = new PlaceOfBirth(childNode);
                        break;
                    case ("КодОКСМ"):
                        OKSMCode = childNode.InnerText;
                        break;
                    case ("СтранаНаименование"):
                        CountryName = childNode.InnerText;
                        break;
                    case ("ПризнакПубЛицо"):
                        PublicPersonMarker = childNode.InnerText;
                        break;
                    case ("АдрРег"):
                        RegAddress = new RegAddress(childNode);
                        break;

                }
            }
        }
    }
}