using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{

    public class Test
    {
        private IWebDriver driver;
        
        private static string word="admin";

        [SetUp]
    public void SetUp()
        {
            driver = new ChromeDriver();
           
        }
        [Test]
        public void NewTest()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 538);
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Name("user")).SendKeys("admin");
            driver.FindElement(By.Name("pass")).SendKeys("secret");
            driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();
            
           // driver.FindElement(By.CssSelector("b")).getText();
            driver.FindElement(By.LinkText("Logout")).Click();
            
            //driver.FindElement(By.TagName("b")).Text;
        }

      


    [TearDown]
        public void TearDown()
        {
            // driver.Quit();
        }
    }
}
