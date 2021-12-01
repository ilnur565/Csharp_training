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

            var contact1 = new ContactCreationData("ILNUR&^&", "FFFFFFFFr");
            app.Contact.EditContact(contact1, 0);

            List<ContactCreationData> newContacts = app.Contact.GetContactList();
            
           // oldContacts.Add(contact1);

            oldContacts.Sort();
            newContacts.Sort();


            Assert.AreEqual(oldContacts, newContacts);
            Assert.AreEqual(oldContacts, newContacts);

            /* ContactCreationtData contactData = new ContactCreationtData("345");
             contact.Lastname = "";

             app.Contact.Modify(1, contactData);*/
        }
    }
}
