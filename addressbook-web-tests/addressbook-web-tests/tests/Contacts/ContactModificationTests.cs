using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            var contact1 = new ContactCreationtData("GGGGGGGG", "FFFFFFFFr");
            app.Contact.EditContact(contact1, 4);


           /* ContactCreationtData contactData = new ContactCreationtData("345");
            contact.Lastname = "";

            app.Contact.Modify(1, contactData);*/
         }
    }
}
