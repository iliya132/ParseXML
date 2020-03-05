using ParseXML.Model;
using ParseXML.Model.ChildNodes;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace ParseXML
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string FilePath = string.Empty;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML Document (*.XML)|*.XML";
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = fileDialog.FileName;
            }
            else
            {
                Environment.Exit(0);
            }

            Console.WriteLine("Работаю...");
            Console.WriteLine("По завершению работы программа закроется автоматически");

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(FilePath);
            XmlElement xElem = xDoc.DocumentElement;
            XmlModel FinalModel = new XmlModel(xElem);

            ExcelWorker excelWorker = new ExcelWorker();
            excelWorker.ImportNodes(FinalModel);
            string fileName = $"Result_{DateTime.Now.ToString("dd.MM.yyyy_mmss")}";
            excelWorker.Save(fileName);
            Process.Start($"{fileName}.xlsx");

        }
    }
}
