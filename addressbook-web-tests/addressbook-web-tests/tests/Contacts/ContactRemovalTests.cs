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

        [Test]
        public void ContactRemovalTest()
        {

            app.Contact.ContactRemovalTest(34);

           /* public void SelectContatct(int index)
            {
                driver.FindElement(By.Id("" + index + "")).Click();
            }
            driver.FindElement(By.XPath("//input[@ type='button'])"));*/
        }
    }
}
