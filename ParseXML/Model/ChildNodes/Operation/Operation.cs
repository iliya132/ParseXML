using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML.Model.ChildNodes.Operation
{
    public class OperationClass
    {
        public XmlNode FromNode;
        public string RecordNumber { get; set; }
        public string RecordType { get; set; }
        public string OperationNumber { get; set; }
        public string TerrorMarker { get; set; }
        private DateTime _operationDate;
        public DateTime OperationDate { get => _operationDate; set => _operationDate = value; }
        private DateTime _discoverDate;
        public DateTime DiscoverDate { get => _discoverDate; set => _discoverDate = value; }
        public string OparationMarkerCode { get; set; }
        public string OperationESPCode { get; set; }
        public string PaymentSystemName { get; set; }
        public string TransactionTime { get; set; }
        public string OperationCode { get; set; }
        public string OperationNOMarker { get; set; }
        public string CurrencyCode { get; set; }
        public string OperationSum { get; set; }
        public string OperationEquiualentSum { get; set; }
        public OperationBase OperationBase { get; set; }
        /// <summary>
        /// Назначение платежа
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Характер операции
        /// </summary>
        public string OperationDescr { get; set; }
        private List<Participant> _participants = new List<Participant>();
        /// <summary>
        /// Участники операции
        /// </summary>
        public List<Participant> Participants { get => _participants; set => _participants = value; }
        /// <summary>
        /// Сведения переводы ДС
        /// </summary>
        public TransactionInfo TransactionInfo { get; set; }
        /// <summary>
        /// Коммент в конце сообщения
        /// </summary>
        public string ReportComment { get; set; }

        public OperationClass(XmlNode node)
        {
            FromNode = node;
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case ("НомерЗаписи"):
                        RecordNumber = childNode.InnerText;
                        break;
                    case ("ТипЗаписи"):
                        RecordType = childNode.InnerText;
                        break;
                    case ("НомерОперация"):
                        OperationNumber = childNode.InnerText;
                        break;
                    case ("ПризнФТр"):
                        TerrorMarker = childNode.InnerText;
                        break;
                    case ("ДатаОперации"):
                        DateTime.TryParse(childNode.InnerText, out _operationDate);
                        break;
                    case ("ДатаВыявления"):
                        DateTime.TryParse(childNode.InnerText, out _discoverDate);
                        break;
                    case ("КодПризнОперации"):
                        OparationMarkerCode = childNode.InnerText;
                        break;
                    case ("ПризнакОперацияЭСП"):
                        OperationESPCode = childNode.InnerText;
                        break;
                    case ("НаимПлатежнаяСистема1"):
                        PaymentSystemName = childNode.InnerText;
                        break;
                    case ("ВремяТранзакцияЭСП"):
                        TransactionTime = childNode.InnerText;
                        break;
                    case ("КодОперации"):
                        OperationCode = childNode.InnerText;
                        break;
                    case ("ПризнНеобОперации"):
                        OperationNOMarker = childNode.InnerText;
                        break;
                    case ("КодВал"):
                        CurrencyCode = childNode.InnerText;
                        break;
                    case ("СумОперации"):
                        OperationSum = childNode.InnerText;
                        break;
                    case ("СумРуб"):
                        OperationEquiualentSum = childNode.InnerText;
                        break;
                    case ("ОснованиеОп"):
                        OperationBase = new OperationBase(childNode);
                        break;
                    case ("НазначениеПлатежа"):
                        Comment = childNode.InnerText;
                        break;
                    case ("УчастникОп"):
                        Participants.Add(new Participant(childNode));
                        break;
                    case ("СведенияПереводыДС"):
                        TransactionInfo = new TransactionInfo(childNode);
                        break;
                    case ("Коммент"):
                        ReportComment = childNode.InnerText;
                        break;
                }
            }
        }
    }
}
