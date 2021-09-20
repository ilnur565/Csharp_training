using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base (manager)
        { 
        }
        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.CssSelector("input:nth-child(87)")).Click();
            return this;
        }

        public ContactHelper ContactCreation(ContactCreationtData contact)
        {
            manager.Navigator.GoToContactsPage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitNewContact();

            return this;
        }

        /*public ContactHelper Modify( object contactData)
        {
            manager.Navigator.GoToContactsPage();
            InitGroupModification();
            FillContactForm(contactData);

            return this;
        }
*/
        private ContactHelper InitGroupModification()
        {
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactCreationtData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            //   driver.FindElement(By.Name("photo")).Click();
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).SendKeys(contact.Home);
            /*driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).SendKeys("1");
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).SendKeys("1");
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("fax")).SendKeys("1");
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys("1");
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).SendKeys("1");
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).SendKeys("1");
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).SendKeys("1");*/
            return this;
        }
        public ContactHelper ContactRemovalTest(int b)
        {

            manager.Navigator.GoToContactsPage();
            SelectContact(b);
            RemoveContact();
            Thread.Sleep(3000);
            //driver.FindElement(By.CssSelector(".left:nth-child(8) > input")).Click();
            driver.SwitchTo().Alert().Accept();

            /*Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Delete 1 addresses?"));*/
            return this;
        }
        public ContactHelper SelectContact( int index)
        {
            driver.FindElement(By.XPath("//input[@id='" + index + "'] ")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactHelper ClearContact( int index)
        {
            manager.Navigator.GoToContactsPage();
            driver.FindElement(By.CssSelector("tr:nth-child("+index+") > .center:nth-child(8) img")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("lastname")).Clear();
            return this;
        }
        public ContactHelper EditContact(ContactCreationtData contact, int value)
        {
            ClearContact(value);
            FillContactForm(contact);
            SibmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }
        public ContactHelper SibmitContactModification() {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            return this;
        }
    }
}


