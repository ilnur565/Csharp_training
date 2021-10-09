using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests: AuthTestBase
    {

        [SetUp]
        public void Preconditions()
        {
            app.Groups.CreateGroupIfNotExists(1);

        }
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("ZZZ");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.Modify(1, newData);
        }
    }
}
