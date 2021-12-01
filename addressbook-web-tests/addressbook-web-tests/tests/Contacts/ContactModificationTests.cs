using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [SetUp]
        public void Preconditions() {
            var contact = new ContactCreationData("Ilnur_", "WWW_");
            app.Contact.CreateContactIfIsNotExsist(1);


        }
        [Test]
        public void ContactModificationTest()
        {
            List<ContactCreationData> oldContacts = app.Contact.GetContactList();

            var contact1 = new ContactCreationData("ILNdf", "Frdf");
            oldContacts[0].Firstname = contact1.Firstname;
            oldContacts[0].Lastname = contact1.Lastname;

            app.Contact.EditContact(contact1, 0);

            List<ContactCreationData> newContacts = app.Contact.GetContactList();

            
            oldContacts.Sort();
            newContacts.Sort();

            //// тестовый коммит

            Assert.AreEqual(oldContacts, newContacts);

            /* ContactCreationtData contactData = new ContactCreationtData("345");
             contact.Lastname = "";

             app.Contact.Modify(1, contactData);*/
        }
    }
}
