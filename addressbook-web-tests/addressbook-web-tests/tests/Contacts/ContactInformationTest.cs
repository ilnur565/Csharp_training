using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTest: AuthTestBase
    {   
        [Test]
        public void TestContactInformation()
        {
           ContactCreationData fromTable= app.Contact.GetContactInformationFromTable(0);
            ContactCreationData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.Allphones, fromForm.Allphones);
            Console.WriteLine(fromTable.Allphones);
        }

        [Test]

        public void ResultNumberTest()
        {
            Console.WriteLine(app.Contact.GetNumberOfSearchResults());
        }
        [Test]

        
        public void GetPictureSize_()
        {   
            
            string size = Convert.ToString(app.Contact.GetPictureSize());
            Console.WriteLine(size);

            app.Contact.CleanUpSize(size);
            size=size.Replace("{Width=", "").Replace(",", "").Replace("Height=", "").Replace("}", "");
            Console.WriteLine(size);
            string[] num =size.Split(' ');
            int[] number = new int[2];
            for (int i = 0; i < 2; i++)
            {
                number[i] = Convert.ToInt32(num[i]);
            }

            /*number[0] = Convert.ToInt32(num[0]);
            number[1] = Convert.ToInt32(num[1]);*/
            Console.WriteLine(number[0] + number[1]);
        }
        [Test]
        public void ResultNumberFromLabelTest()
        {
            Console.WriteLine(app.Contact.GetNumberOfSearchResultsLabel());
        }
    }
}
