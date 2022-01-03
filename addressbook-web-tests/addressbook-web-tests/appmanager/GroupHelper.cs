﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase 
    {

        public GroupHelper(ApplicationManager manager): base (manager)
        {
         
        }

        public void CreateGroupIfNotExists(int index)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]"))){
                var group = new GroupData("123");
               Create(group);
            }
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;

        }

       

        public GroupHelper Modify(int p, GroupData newData)
        {

            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        private List<GroupData> groupCache = null;

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//span[@class='group'])"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupCache);
        }
        /*
                public List<GroupData> GetGroupList()
                {



                    if (groupCache == null)
                    {
                        groupCache = new List<GroupData>();
                        manager.Navigator.GoToGroupsPage();
                        ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//span[@class='group'])"));
                        foreach (IWebElement element in elements)
                        {
                            GroupData group = new GroupData(null)
                            {
                                Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                            };

                            groupCache.Add(group);
                        }
                        string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                        string[] parts = allGroupNames.Split('\n');*//* allGroupNames.Split();*//*
                        int shift = groupCache.Count - parts.Length;
                        for (int i = 0; i < groupCache.Count; i++)
                        {
                            if (i<shift )
                            {
                                groupCache[i].Name = "";
                            }
                            else
                            {
                                groupCache[i].Name =parts[i-shift].Trim();

                            }


                        }

                    }
                        return new List<GroupData>(groupCache);
                }*/

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this; 

        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type (By.Name("group_name"), group.Name);
            Type (By.Name("group_header"), group.Header);
            Type (By.Name("group_footer"), group.Footer);
            return this;
        }

        public void Type(By locator, string text)
        {
            if (text != null) 
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);

            }
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;

        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }


        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;

        }
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;

        }
    }
}
