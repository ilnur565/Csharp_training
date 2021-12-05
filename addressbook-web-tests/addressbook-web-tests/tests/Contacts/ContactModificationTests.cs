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
            ContactCreationData oldData = oldContacts[0];

            var newContact1 = new ContactCreationData("ILNdddccddcU", "dFccdd1");
            app.Contact.EditContact(newContact1, 0);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());
            List<ContactCreationData> newContacts = app.Contact.GetContactList();
            ContactCreationData newData = newContacts[0];

            // oldContacts.Add(contact1);

            oldContacts[0].Firstname = newContact1.Firstname;
            oldContacts[0].Lastname = newContact1.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            



            Assert.AreEqual(oldContacts, newContacts);
            foreach(ContactCreationData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newContact1.Firstname, contact.Firstname);
                    Assert.AreEqual(newContact1.Lastname, contact.lastname);
                }
            }

            /* ContactCreationtData contactData = new ContactCreationtData("345");
             contact.Lastname = "";

             app.Contact.Modify(1, contactData);*/
        }
    }
}
