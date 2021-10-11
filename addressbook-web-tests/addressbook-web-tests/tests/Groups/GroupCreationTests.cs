// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using addressbook_web_tests;

namespace addressbook_web_tests
{

    [TestFixture]
    public class GroupCreationTests : AuthTestBase
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
        [Test]
        public void GroupCreationTest()
        {

            var group = new GroupData("Ilnur");
            group.Header = "1234";
            group.Footer = "2";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            
            List<GroupData> newGroups = app.Groups.GetGroupList(); // ��������� ��� ��������� �.� ������ ������� ������ ����� ������ ��������
            Assert.AreEqual(oldGroups.Count+1, newGroups.Count);
            System.Console.Out.Write(oldGroups.Count+newGroups.Count);
            //app.Auth.Logout();
          

            
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            
            var group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList(); // ��������� ��� ��������� �.� ������ ������� ������ ����� ������ ��������
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            //app.Auth.Logout();
        }

    }
}