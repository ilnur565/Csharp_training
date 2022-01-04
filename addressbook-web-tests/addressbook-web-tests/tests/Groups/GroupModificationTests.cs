using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests: GroupTestBase
    {

        [SetUp]
        public void Preconditions()
        {
            app.Groups.CreateGroupIfNotExists(0);

        }
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("ZZdadsscZ");
            newData.Header = null;
            newData.Footer = null;
            
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];
            app.Groups.Modify(oldData, newData);

             
            List<GroupData> newGroups = GroupData.GetAll(); // Контейнер или коллекция т.е объект который хранит набор других объектов
            
            oldGroups[0].Name=newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {

                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name); 
                }
                
            }

        }
    }
}
