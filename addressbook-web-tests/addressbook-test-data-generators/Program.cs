using System;
using System.Collections.Generic;
using System.IO;
using addressbook_web_tests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {

           
            int count = Convert.ToInt32(args[0]);
            string format = args[1];

            string path = @"C:\Users\User\source\repos\Csharp_training\addressbook-web-tests\addressbook-test-data-generators\bin\Debug\net5.0\group.xlsx";
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header= TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)

                });
               
            }
            if (format == "excel")
            {

                writeGroupsToExcelFile(groups, path);

            }
            else 
            {
                StreamWriter writer = new StreamWriter(@"C:\Users\User\source\repos\Csharp_training\addressbook-web-tests\addressbook-web-tests\group.xml");

                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);

                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }

                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            }
        }

         static void writeGroupsToExcelFile(List<GroupData> groups, string path)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();    
            Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;
            sheet.Cells[1, 1] = "test";

        }

        static void writeGroupsToCsvFile(List <GroupData> groups, StreamWriter writer)
        {
            foreach(GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer)); 
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);

        }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }


       


    }
}
    