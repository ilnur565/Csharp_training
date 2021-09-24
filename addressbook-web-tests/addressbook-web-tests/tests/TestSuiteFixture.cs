using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{   
    [SetUpFixture]
    public class TestSuiteFixture
    {
        public static ApplicationManager app;

        [SetUp]
        public  void InitApplicationManager()
        {
            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
        [TearDown]
        public void StopApplicationManager()
        {
            app.Stop();
        }
    }
}
