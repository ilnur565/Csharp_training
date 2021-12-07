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
        private bool z;

        public LoginHelper(ApplicationManager manager): base(manager) // так  как имеем один общий класс для помощников - HelperBase, то обращаемся так к его конструктору
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account)) 
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();
        }
        public void Logout()
        {
            if (IsLoggedIn()) { 
            driver.FindElement(By.LinkText("Logout")).Click();
            driver.FindElement(By.CssSelector("html")).Click();
            }
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Logout"));
        }




        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && GetLoggetUsername() == account.Username;
        }



        public string GetLoggetUsername()
        {

            string text = driver.FindElement(By.TagName("b")).Text;

            return text.Substring(1, text.Length - 2);
        }




    }
}
