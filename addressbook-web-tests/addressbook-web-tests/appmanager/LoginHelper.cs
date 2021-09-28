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
            bool z=false;
            try
            {

                string a = driver.FindElement(By.LinkText("Logout")).Text;//Проверили наличие Logout

                string b = driver.FindElement(By.TagName("b")).Text; // нашли на странице текст:(admin)  
                string c = "(" + account.Username + ")"; // записали в переменную с название уз
                if (b == c)
                {
                    z = true;
                    System.Console.Out.Write(z);
                }
            }
            catch { }

            return IsLoggedIn() && z;
        }




    }
}
