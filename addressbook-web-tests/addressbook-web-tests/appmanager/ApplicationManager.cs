 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);   
        }
         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
            }

        }
       
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;

            }

            return app.Value;   
        }
       
        public LoginHelper Auth 
        {
            get
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContactHelper Contact
        {
            get
            {
                return contactHelper;
            }
        }

        public IWebDriver Driver 
        { get 
            {
                return driver;
            }
        }
        
    }   
}
