using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [SetUp]
        public void Preconditions() {
            var contact = new ContactCreationtData("Ilnur_", "WWW_");
            app.Contact.CreateContactIfIsNotExsist(1);


        }
        [Test]
        public void ContactModificationTest()
        {
            var contact1 = new ContactCreationtData("ILNUR&^&", "FFFFFFFFr");
            app.Contact.EditContact(contact1, 2);


           /* ContactCreationtData contactData = new ContactCreationtData("345");
            contact.Lastname = "";

            app.Contact.Modify(1, contactData);*/
         }
    }
}
