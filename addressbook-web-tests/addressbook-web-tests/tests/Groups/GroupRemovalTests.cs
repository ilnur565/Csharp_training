﻿// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace addressbook_web_tests
{

    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [SetUp]
        public void Preconditions()
        {
            app.Groups.CreateGroupIfNotExists(1);

        }
       
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            /* app.Navigator.GoToGroupsPage();
             app.Groups
                 .SelectGroup(5)
                 .RemoveGroup()
                 .ReturnToGroupsPage();*/
        }      
    }
}