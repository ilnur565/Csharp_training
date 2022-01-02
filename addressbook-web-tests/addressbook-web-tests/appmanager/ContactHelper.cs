using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Drawing;

using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base (manager)
        { 
        }
        private List<ContactCreationData> contactCache = null;

        public ContactCreationData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
              .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;
            
            return new ContactCreationData(firstname, lastname)
            {
                Address = address,
                Allphones = allPhones,
                AllEmails = allEmails,
                

            };
        }

        public string ConvertContactDataToString(ContactCreationData contact)
        {
            return GetContactString(contact);

           /* return contact.Firstname + " "
                + contact.Lastname + "\r\n"
                 + contact.Address + "\r\n\r\n"
                + "H: " + contact.HomePhone + "\r\n"
                + "M: " + contact.MobilePhone + "\r\n"
                + "W: " + contact.WorkPhone + "\r\n"
                + contact.Email + "\r\n"
                + contact.Email2 + "\r\n"
                + contact.Email3 + "\r\n";*/

        }

        public string GetContactString(ContactCreationData contact)
        {
            string total = "";
            if (contact.Firstname != null && contact.Firstname != "")
            {
                total += contact.Firstname;
                if (contact.Lastname != null && contact.Lastname != "")
                    total += " ";
                else
                {
                    if ((contact.Address != null && contact.Address != "")
                        || (contact.AllPhonesWithPrefix != null && contact.AllPhonesWithPrefix != "")
                        || (contact.AllEmails != null && contact.AllEmails != ""))
                        total += "\r\n";
                }
            }

            if (contact.Lastname != null && contact.Lastname != "")
            {
                total += contact.Lastname;
                if ((contact.Address != null && contact.Address != "")
                    || (contact.AllPhonesWithPrefix != null && contact.AllPhonesWithPrefix != "")
                    || (contact.AllEmails != null && contact.AllEmails != ""))
                    total += "\r\n";
            }

            if (contact.Address != null && contact.Address != "")
            {
                total += contact.Address;
                if ((contact.AllPhonesWithPrefix != null && contact.AllPhonesWithPrefix != "")
                        || (contact.AllEmails != null && contact.AllEmails != ""))
                    total += "\r\n";
            }

            if (contact.AllPhonesWithPrefix != null && contact.AllPhonesWithPrefix != "")
            {
                if ((contact.Firstname != null && contact.Firstname != "")
                    || (contact.Lastname != null && contact.Lastname != "")
                    || (contact.Address != null && contact.Address != ""))
                    total += "\r\n";
                total += contact.AllPhonesWithPrefix;
                if (contact.AllEmails != null && contact.AllEmails != "")
                    total += "\r\n";
                else total = total.Trim();
            }

            if (contact.AllEmails != null && contact.AllEmails != "")
            {
                if ((contact.Firstname != null && contact.Firstname != "")
                    || (contact.Lastname != null && contact.Lastname != "")
                    || (contact.Address != null && contact.Address != "")
                    || (contact.AllPhonesWithPrefix != null && contact.AllPhonesWithPrefix != ""))
                    total += "\r\n";
                total += contact.AllEmails.Trim();
            }
            return total;

        }




        public string GetContactInformationFromDeatails(int index)
        {
            GoToContactDetails(index);
            return driver.FindElement(By.XPath("//div[@id='content']")).Text;
        }

        public void GoToContactDetails(int index )
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("(//img[@ title='Details'])["+(index+1)+"]")).Click();

        }

        public ContactCreationData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactCreationData(firstName, lastName)
            { Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone= workPhone,
                
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click(); 
        }

        public List<ContactCreationData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactCreationData>();
                manager.Navigator.GoToContactsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//tr[@name='entry'])"));
                
                foreach (IWebElement element in elements)
                {
                    var td = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactCreationData(td[2].Text, td[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

                }
            }

            
            return new List < ContactCreationData > (contactCache);
        }

        public int GetContactCount()

        {
            manager.Navigator.GoToContactsPage();
            return driver.FindElements(By.XPath("(//tr[@name='entry'])")).Count;
        }

        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.CssSelector("input:nth-child(87)")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ContactCreation(ContactCreationData contact)
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

        public ContactHelper FillContactForm(ContactCreationData contact)
        {

            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            //   driver.FindElement(By.Name("photo")).Click();
            Type(By.Name("home"), contact.Home);

            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.MobilePhone);
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).SendKeys(contact.WorkPhone);
            //driver.FindElement(By.Name("fax")).Click();
            //driver.FindElement(By.Name("fax")).SendKeys("1");
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email3);
            //driver.FindElement(By.Name("homepage")).Click();
            //driver.FindElement(By.Name("homepage")).SendKeys("1");
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
        public ContactHelper AllContactRemovalTest()
        {

            manager.Navigator.GoToContactsPage();
            SelectALLContact();
            RemoveContact();
            Thread.Sleep(3000);
            //driver.FindElement(By.CssSelector(".left:nth-child(8) > input")).Click();
            driver.SwitchTo().Alert().Accept();

            /*Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Delete 1 addresses?"));*/
            return this;
        }
        public void CreateContactIfIsNotExsist(int index)
        {
            manager.Navigator.GoToContactsPage();
            if(!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")) )
            {
                var contact = new ContactCreationData("Ilnur_V2", "WWW_V2");
                ContactCreation(contact);
            }
        }

        public ContactHelper SelectContact( int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" +( index +1)+ "]")).Click();
            return this;
        }
        public ContactHelper SelectALLContact()
        {
            driver.FindElement(By.XPath("(//input[@onclick='MassSelection()'])")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper ClearContact( int index)
        {
            manager.Navigator.GoToContactsPage();
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index +1)+ "]")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("lastname")).Clear();
            return this;
        }
        public ContactHelper EditContact(ContactCreationData contact, int value)
        {
            ClearContact(value);
            FillContactForm(contact);
            SibmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }
        public ContactHelper SibmitContactModification() {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            contactCache = null;
            return this;
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToContactsPage();
            return Convert.ToInt32(driver.FindElement(By.XPath("//span[@ id='search_count']")).Text);
            
        }
        public int GetNumberOfSearchResultsLabel()
        {
            manager.Navigator.GoToContactsPage();
            string text= driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
             
        }
        public Size GetPictureSize()
        {
            manager.Navigator.GoToContactsPage();
           // Size []s = new Size[2];
            return  driver.FindElement(By.XPath("//img[@ title='Addressbook']")).Size;

        }
        public void  PictureClick(int index)
        {
            manager.Navigator.GoToContactsPage();
            // Size []s = new Size[2];
             driver.FindElement(By.XPath("(//img[@ title='Details'])[" + index+"]")).Click();

        }
        public string CleanUpSize(string size)
        {
            //return Regex.Replace(size, "[{Width=,Height=}]", "");
            return size.Replace("{Width=", "").Replace(",", "").Replace("Height=", "").Replace("}", "");
        }
    }
}



