using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using ParseXML.Model;
using ParseXML.Model.ChildNodes;
using ParseXML.Model.ChildNodes.Operation;

namespace ParseXML
{
    public class ExcelWorker
    {
        ExcelPackage excel;
        ExcelWorksheet sheet;
        public ExcelWorker()
        {
            excel = new ExcelPackage();
            sheet = excel.Workbook.Worksheets.Add("sheet1");
        }

        public void ImportNodes(XmlModel xmlModel)
        {
            PlaceHeaders(xmlModel);
            int row = 3;
            int col = 1;
            ServicePart servicePart = xmlModel.ServicePart;
            InfoPart infoPart = xmlModel.InfoPart;
            foreach (Intelligence intel in infoPart.Intelligences)
            {
                foreach (OperationClass operation in intel.Operations)
                {
                    #region input part
                    write(row, col++, servicePart.Version);
                    write(row, col++, servicePart.ProgramVersion);
                    write(row, col++, servicePart.CorId);
                    write(row, col++, servicePart.InfoType);
                    if (servicePart.MessageDate.Year > 100) 
                        write(row, col++, servicePart.MessageDate.ToString("dd.MM.yyyy"));
                    else
                        write(row, col++, string.Empty);
                    write(row, col++, servicePart.AuthorizedUserPosition);
                    write(row, col++, servicePart.Fio.LastName);
                    write(row, col++, servicePart.Fio.FirstName);
                    write(row, col++, servicePart.Fio.Patronymic);
                    write(row, col++, servicePart.PhoneNumber);
                    write(row, col++, servicePart.Email);
                    write(row, col++, infoPart.bankInfo.RegNumber);
                    write(row, col++, infoPart.bankInfo.BIKKO);
                    write(row, col++, infoPart.bankInfo.OKATO);
                    write(row, col++, intel.InfoGiveMarker);
                    if (intel.FilialInfo == null)
                    {
                        col = col + 4;
                    }
                    else
                    {
                        write(row, col++, intel.FilialInfo.RegNumber);
                        write(row, col++, intel.FilialInfo.FilialNumber);
                        write(row, col++, intel.FilialInfo.BIK);
                        write(row, col++, intel.FilialInfo.OKATO);
                    }
                    write(row, col++, operation.RecordNumber);
                    write(row, col++, operation.RecordType);
                    write(row, col++, operation.OperationNumber);
                    write(row, col++, operation.TerrorMarker);
                    if (operation.OperationDate.Year > 100)
                        write(row, col++, operation.OperationDate.ToString("dd.MM.yyyy"));
                    else write(row, col++, string.Empty);
                    if (operation.DiscoverDate.Year > 100)
                        write(row, col++, operation.DiscoverDate.ToString("dd.MM.yyyy"));
                    else 
                        write(row, col++, string.Empty);

                    write(row, col++, operation.OparationMarkerCode);
                    write(row, col++, operation.OperationESPCode);
                    write(row, col++, operation.PaymentSystemName);
                    write(row, col++, operation.TransactionTime);
                    write(row, col++, operation.OperationCode);
                    write(row, col++, operation.OperationNOMarker);
                    write(row, col++, operation.CurrencyCode);
                    write(row, col++, operation.OperationSum);
                    write(row, col++, operation.OperationEquiualentSum);
                    write(row, col++, operation.OperationBase.DocumentCode);
                    write(row, col++, operation.OperationBase.DocName);
                    if(operation.OperationBase.DocDate.Year>100)
                        write(row, col++, operation.OperationBase.DocDate.ToString("dd.MM.yyyy"));
                    else
                        write(row, col++, string.Empty);
                    write(row, col++, operation.OperationBase.DocumentNumber);
                    write(row, col++, operation.Comment);
                    write(row, col++, operation.OperationDescr);
                    foreach (Participant participant in operation.Participants)
                    {
                        write(row, col++, participant.Status);
                        write(row, col++, participant.ParticipantType);
                        write(row, col++, participant.ParticipantMarker);
                        write(row, col++, participant.ClientMarker);
                        #region UL
                        if (participant.UL == null)
                        {
                            col = col + 59;
                        }
                        else
                        {


                            if (participant.UL.ULInfo == null)
                            {
                                col = col + 26;
                            }
                            else
                            {
                                write(row, col++, participant.UL.ULInfo?.Name);
                                write(row, col++, participant.UL.ULInfo?.FLMarker);
                                write(row, col++, participant.UL.ULInfo?.INN);
                                write(row, col++, participant.UL.ULInfo?.KPP);
                                write(row, col++, participant.UL.ULInfo?.OGRN);
                                write(row, col++, participant.UL.ULInfo?.AddressRegUL?.Index);
                                write(row, col++, participant.UL.ULInfo?.AddressRegUL?.OKSMCode);
                                write(row, col++, participant.UL.ULInfo?.AddressRegUL?.CountryName);
                                write(row, col++, participant.UL.ULInfo?.AddressRegUL?.OKATOSubjectCode);
                                write(row, col++, participant.UL.ULInfo?.AddressRegUL?.Area);
                                write(row, col++, participant.UL.ULInfo?.AddressRegUL?.City);
                                write(row, col++, participant.UL.ULInfo?.AddressRegUL?.Street);
                                write(row, col++, participant.UL.ULInfo?.AddressRegUL?.House);
                                write(row, col++, participant.UL.ULInfo?.AddressRegUL?.HouseBuilding);
                                write(row, col++, participant.UL.ULInfo?.AddressRegUL?.Office);
                                if(participant.UL.ULInfo!=null && participant.UL.ULInfo.RegDate.Year>100)
                                    write(row, col++, participant.UL.ULInfo?.RegDate.ToString("dd.MM.yyyy"));
                                else
                                    write(row, col++, string.Empty);
                                write(row, col++, participant.UL.ULInfo?.AddressUL?.Index);
                                write(row, col++, participant.UL.ULInfo?.AddressUL?.OKSMCode);
                                write(row, col++, participant.UL.ULInfo?.AddressUL?.CountryName);
                                write(row, col++, participant.UL.ULInfo?.AddressUL?.OKATOSubjectCode);
                                write(row, col++, participant.UL.ULInfo?.AddressUL?.Area);
                                write(row, col++, participant.UL.ULInfo?.AddressUL?.City);
                                write(row, col++, participant.UL.ULInfo?.AddressUL?.Street);
                                write(row, col++, participant.UL.ULInfo?.AddressUL?.House);
                                write(row, col++, participant.UL.ULInfo?.AddressUL?.HouseBuilding);
                                write(row, col++, participant.UL.ULInfo?.AddressUL?.Office);
                            }
                            #endregion
                            #region eio
                            if (participant.UL.EIOInfo == null)
                            {
                                col = col + 33;
                            }
                            else
                            {
                                if(participant.UL.EIOInfo.EIOFL == null)
                                {
                                    Console.WriteLine(participant.UL.EIOInfo.FromNode.InnerText);
                                }
                                write(row, col++, participant.UL.EIOInfo.EIOType);
                                write(row, col++, participant.UL.EIOInfo.EIOMarker);

                                write(row, col++, participant.UL.EIOInfo.EIOFL.FLFIO.LastName);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.FLFIO.FirstName);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.FLFIO.Patronymic);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.INN);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.DocumentType);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.DocumentInfo?.DocumentType);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.DocumentInfo?.DocumentTypeName);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.DocumentInfo?.Series);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.DocumentInfo?.Number);
                                if(participant.UL.EIOInfo.EIOFL.DocumentInfo != null && participant.UL.EIOInfo.EIOFL.DocumentInfo?.GivenDate.Year>100)
                                    write(row, col++, participant.UL.EIOInfo.EIOFL.DocumentInfo?.GivenDate.ToString("dd.MM.yyyy"));
                                else
                                    write(row, col++, string.Empty);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.DocumentInfo?.GivenBy);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.DocumentInfo?.KPPName);
                                if(participant.UL.EIOInfo.EIOFL.BirthDay.Year>100)
                                    write(row, col++, participant.UL.EIOInfo.EIOFL.BirthDay.ToString("dd.MM.yyyy"));
                                else
                                    write(row, col++, string.Empty);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.PlaceOfBirth?.OKSMCode);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.PlaceOfBirth?.CountryName);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.PlaceOfBirth?.OKATOSubjectName);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.PlaceOfBirth?.Area);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.PlaceOfBirth?.City);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.OKSMCode);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.CountryName);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.PublicPersonMarker);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.RegAddress?.Index);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.RegAddress?.OKSMCode);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.RegAddress?.CountryName);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.RegAddress?.OKATOSubjectName);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.RegAddress?.Area);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.RegAddress?.City);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.RegAddress?.Street);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.RegAddress?.House);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.RegAddress?.HouseBuilding);
                                write(row, col++, participant.UL.EIOInfo.EIOFL.RegAddress?.Office);
                                
                            }
                        }
                        #endregion
                        write(row, col++, participant.ParticipantComment);
                    }
                    if (operation.TransactionInfo == null)
                    {
                        col = col + 5;
                    }
                    else
                    {
                        write(row, col++, operation.TransactionInfo.Vid);
                        write(row, col++, operation.TransactionInfo.Type);
                        write(row, col++, operation.TransactionInfo.AccountPayer);
                        write(row, col++, operation.TransactionInfo.ESPLIdentity);
                        write(row, col++, operation.TransactionInfo.AccountReciever);

                        if (operation.TransactionInfo.AuthorizationInfo == null)
                        {
                            col = col + 5;
                        }
                        else
                        {
                            write(row, col++, operation.TransactionInfo.AuthorizationInfo.TerminalId);
                            write(row, col++, operation.TransactionInfo.AuthorizationInfo.TransactionPlace.OKSM);
                            write(row, col++, operation.TransactionInfo.AuthorizationInfo.TransactionPlace.CountryName);
                            write(row, col++, operation.TransactionInfo.AuthorizationInfo.TransactionPlace.OKATOSubjectCode);
                            write(row, col++, operation.TransactionInfo.AuthorizationInfo.TransactionPlace.City);
                        }
                    }
                    #endregion
                    write(row, col++, operation.ReportComment);
                    row++;
                    col = 1;
                }
            }

        }

        internal void Save(string path)
        {
            excel.SaveAs(new System.IO.FileInfo($"{path}.xlsx"));
            excel.Dispose();
            sheet.Dispose();
        }

        private void PlaceHeaders(XmlModel xmlModel)
        {
            int row = 2;
            int col = 1;
            

            ServicePart servicePart = xmlModel.ServicePart;
            InfoPart infoPart = xmlModel.InfoPart;
            foreach (Intelligence intel in infoPart.Intelligences)
            {
                int operationNumber = 0;
                foreach (OperationClass operation in intel.Operations)
                {
                    operationNumber++;
                    int participantNumber = 0;
                    #region input part
                    write(row - 1, col, "СлужЧасть");
                    write(row, col++, "ВерсияФормата");
                    write(row, col++, "Версия программы");
                    write(row, col++, "ИДКорр");
                    write(row, col++, "ТипИнф");
                    write(row, col++, "ДатаСообщения");
                    write(row, col++, "УполнСотрудн");
                    write(row, col++, "Фамилия");
                    write(row - 1, col, "ФИО Уполномоченного сотрудника");
                    write(row, col++, "Имя");
                    write(row, col++, "Отчество");
                    write(row, col++, "Телефон");
                    write(row, col++, "Email");
                    write(row - 1, col, "ИнформЧасть");
                    write(row, col++, "РегНомКО");
                    write(row, col++, "БИККО");
                    write(row, col++, "ОКАТОКО");
                    write(row, col++, "ПризнакПредставСвед");
                    write(row, col++, "РегНомКО");
                    write(row, col++, "НомФл");
                    write(row, col++, "БИКФл");
                    write(row, col++, "ОКАТОФл");
                    write(row - 1, col, $"Операция{operationNumber}");
                    write(row, col++, "Номер записи");
                    write(row, col++, "Тип записи");
                    write(row, col++, "Номер операции");
                    write(row, col++, "Признак фТр");
                    write(row, col++, "Дата операции");
                    write(row, col++, "Дата выявления");
                    write(row, col++, "Код признака операции");
                    write(row, col++, "ПризнакОперацияЭСП");
                    write(row, col++, "НаимПлатежнаяСистема1");
                    write(row, col++, "ВремяТранзакцияЭСП");
                    write(row, col++, "КодОперации");
                    write(row, col++, "ПризнНеобОперации");
                    write(row, col++, "КодВал");
                    write(row, col++, "СумОперации");
                    write(row, col++, "СумРуб");
                    write(row - 1, col, $"Основание операции{operationNumber}");
                    write(row, col++, "Код документа");
                    write(row, col++, "Наименование документа");
                    write(row, col++, "Дата документа");
                    write(row, col++, "Номер документа");
                    write(row, col++, "НазначениеПлатежа");
                    write(row, col++, "ХарактерОп");

                    write(row - 1, col, $"Основание операции{participantNumber}");
                    foreach (Participant participant in operation.Participants)
                    {
                        participantNumber++;
                        write(row - 1, col, $"Участник{participantNumber}");
                        write(row, col++, "Статус участника");
                        write(row, col++, "ТипУчастника");
                        write(row, col++, "ПризнУчастника");
                        write(row, col++, "ПризнКлиент");
                        #region UL

                        write(row - 1, col, $"УчастникЮЛ");
                        write(row, col++, "НаимЮЛ");
                        write(row, col++, "ПризнакФлЮЛ");
                        write(row, col++, "ИННЮЛ");
                        write(row, col++, "КППЮЛ");
                        write(row, col++, "ОГРНЮЛ");

                        write(row - 1, col, $"АдресРегистрации");
                        write(row, col++, "Индекс");
                        write(row, col++, "КодОКСМ");
                        write(row, col++, "СтранаНаименование");
                        write(row, col++, "КодСубъектаПоОКАТО");
                        write(row, col++, "Район");
                        write(row, col++, "Пункт");
                        write(row, col++, "Улица");
                        write(row, col++, "Дом");
                        write(row, col++, "Корп");
                        write(row, col++, "Оф");
                        write(row, col++, "Дата регистрации");

                        write(row - 1, col, $"АдрЮЛ");
                        write(row, col++, "Индекс");
                        write(row, col++, "КодОКСМ");
                        write(row, col++, "СтранаНаименование");
                        write(row, col++, "КодСубъектаПоОКАТО");
                        write(row, col++, "Район");
                        write(row, col++, "Пункт");
                        write(row, col++, "Улица");
                        write(row, col++, "Дом");
                        write(row, col++, "Корпус");
                        write(row, col++, "Офис");
                        #endregion
                        #region eio

                        write(row - 1, col, $"СведЕИО");
                        write(row, col++, "ТипЕИО");
                        write(row, col++, "ПризнЕИО");
                        write(row - 1, col, $"ФИОФЛИП");
                        write(row, col++, "Фамилия");
                        write(row, col++, "Имя");
                        write(row, col++, "Отчество");
                        write(row, col++, "ИНН");
                        write(row, col++, "ДокУдЛичн");
                        write(row, col++, "ВидДокКод");
                        write(row, col++, "ВидДокНаименование");
                        write(row, col++, "СерияДок");
                        write(row, col++, "НомДок");
                        write(row, col++, "ДатВыдачиДок");
                        write(row, col++, "КемВыданДок");
                        write(row, col++, "КодПодр");
                        write(row, col++, "ДатаРождения");

                        write(row - 1, col, $"Место рождения");
                        write(row, col++, "КодОКСМ");
                        write(row, col++, "СтранаНаименование");
                        write(row, col++, "КодСубъектаПоОКАТО");
                        write(row, col++, "Район");
                        write(row, col++, "Пункт");
                        write(row, col++, "КодОКСМ");
                        write(row, col++, "СтранаНаименование");
                        write(row, col++, "ПризнакПубЛицо");
                        write(row - 1, col, $"Адрес регистрации");
                        write(row, col++, "Индекс");
                        write(row, col++, "КодОКСМ");
                        write(row, col++, "СтранаНаименование");
                        write(row, col++, "КодСубъектаПоОКАТО");
                        write(row, col++, "Район");
                        write(row, col++, "Пункт");
                        write(row, col++, "Улица");
                        write(row, col++, "Дом");
                        write(row, col++, "Корпус");
                        write(row, col++, "Офис");
                        #endregion
                        write(row, col++, "КомментУчастник");

                    }
                    write(row - 1, col, $"СведенияПереводыДС");
                    write(row, col++, "ВидПереводДС");
                    write(row, col++, "ТипОператорДС");
                    write(row, col++, "НомерСчетПлательщик");
                    write(row, col++, "ИдентЭСППлательщик");
                    write(row, col++, "НомерСчетПолучатель");
                    write(row - 1, col, $"СведАвторизацияЭСП");
                    write(row, col++, "ИдТерминал");
                    write(row - 1, col, $"АдрМестаПриемаВыдача");
                    write(row, col++, "КодОКСМ");
                    write(row, col++, "СтранаНаименование");
                    write(row, col++, "КодСубъектаПоОКАТО");
                    write(row, col++, "Пункт");
                    #endregion
                    write(row, col++, "Коммент");
                    col = 1;
                }
            }
        }

        private void write(int x, int y, string Text) => sheet.Cells[x, y].Value = Text;
    }
}
