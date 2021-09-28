using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public  class NavigationHelper : HelperBase
    {

        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
           
        }
        public void GoToHomePage()
        {
            if(driver.Url == "http://localhost/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 538);
            driver.Manage().Window.Maximize();
        }

        public void GoToGroupsPage()
        {
            if(driver.Url == "http://localhost/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void GoToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
