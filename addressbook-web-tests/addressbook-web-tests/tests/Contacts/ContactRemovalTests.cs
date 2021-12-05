using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]

    public class ContactRemovalTests : AuthTestBase

    {

        [SetUp]
        public void Preconditions()
        {
            var contact = new ContactCreationData("Ilnur_", "WWW_");
            app.Contact.CreateContactIfIsNotExsist(1);
        }

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactCreationData> oldContacts = app.Contact.GetContactList();
            ContactCreationData oldData = oldContacts[0];
            app.Contact.ContactRemovalTest(0);
            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactCreationData> newContacts = app.Contact.GetContactList();
            ContactCreationData newData = newContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactCreationData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, oldData.Id);
            }
            /* public void SelectContatct(int index)
             {
                 driver.FindElement(By.Id("" + index + "")).Click();
             }
             driver.FindElement(By.XPath("//input[@ type='button'])"));*/
        }

        [Test]
        public void AllContactRemovalTest()
        {

            app.Contact.AllContactRemovalTest();

            /* public void SelectContatct(int index)
             {
                 driver.FindElement(By.Id("" + index + "")).Click();
             }
             driver.FindElement(By.XPath("//input[@ type='button'])"));*/
        }
    }
}
