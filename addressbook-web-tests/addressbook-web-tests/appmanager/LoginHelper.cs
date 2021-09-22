using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests
{
     public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager): base(manager) // так  как имеем один общий класс для помощников - HelperBase, то обращаемся так к его конструктору
        {
        }
        public void Login(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();
        }
        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            driver.FindElement(By.CssSelector("html")).Click();
        }
    }
}
