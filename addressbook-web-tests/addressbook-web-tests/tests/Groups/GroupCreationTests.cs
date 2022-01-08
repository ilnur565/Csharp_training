// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using addressbook_web_tests;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;
//using addressbook_web_tests.model;

namespace addressbook_web_tests
{

    [TestFixture]
    public class GroupCreationTests : GroupTestBase 
    {
        /*[Test]
        public void GroupCreationTest()
        {

            GroupData group = new GroupData("34563457");
            group.Header = "d2";
            group.Footer = "f2";
            app.Navigator.GoToGroupsPage();
            app.Groups
                .InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
            //app.Auth.Logout();
        }*/

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            string path = @"C: \Users\User\source\repos\Csharp_training\addressbook-web-tests\addressbook-web-tests\group.xml";


            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(path));


        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            string path = @"C:\Users\User\source\repos\Csharp_training\addressbook-web-tests\addressbook-web-tests\group.json";

            return JsonConvert.DeserializeObject<List<GroupData>>(
                 File.ReadAllText(path));
        }
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"C:\Users\User\source\repos\Csharp_training\addressbook-web-tests\addressbook-web-tests\group.csv");

            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });

            }
            return groups;
        }

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }



        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);  
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll(); // ��������� ��� ��������� �.� ������ ������� ������ ����� ������ ��������


            oldGroups.Add(group);

            newGroups.Sort();
            oldGroups.Sort();
            Assert.AreEqual(newGroups, oldGroups);
            System.Console.Out.Write(Convert.ToString(oldGroups.Count) + newGroups.Count);
            //app.Auth.Logout();



        }

        [Test]
        public void EmptyGroupCreationTest()
        {

            var group1 = new GroupData("c");
            group1.Header = "s";
            group1.Footer = "g";

            List<GroupData> oldGroups = GroupData.GetAll(); ;

            app.Groups.Create(group1);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();  // ��������� ��� ��������� �.� ������ ������� ������ ����� ������ ��������


            oldGroups.Add(group1);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            //app.Auth.Logout();
        }
        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;

            List<GroupData> fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.WriteLine(end.Subtract(start));

            DateTime start1 = DateTime.Now;
            List<GroupData> fromDb = GroupData.GetAll();
            DateTime end1 = DateTime.Now;
            System.Console.WriteLine(end1.Subtract(start1));
        }
        [Test] // ����� ���� ���� �����
        public void AllGrouopNames() 
        {
            List<GroupData> fromDb = GroupData.GetAll();
            int i;
            int max = fromDb.Count;
            Console.WriteLine(max);
            string[] names=new string[max];
            for (i = 0; i < max; i++)
            {
                names[i] = fromDb[i].Name;
                Console.WriteLine(fromDb[i].Name);
            }
            


        }
        [Test]
        public void TestDBConnectivity2()
        {
            foreach (ContactCreationData contact in GroupData.GetAll()[0].GetContacts())
            {
                System.Console.Out.WriteLine(contact);
                System.Console.Out.WriteLine("====");
            }
            System.Console.Out.WriteLine(GroupData.GetAll().Count);

        }
        [Test]
        public void TestDBConnectivity3()
        {
            var qwer = new GroupContactRelation();
            System.Console.Out.WriteLine(qwer.GetGroupContactRelation().Count);
            System.Console.Out.WriteLine(GroupData.GetAll()[0].Name);

        }

    }
}