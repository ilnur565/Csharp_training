using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace addressbook_web_tests
{
    

    public class TestMethod
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMethod1()
        {
            string[] s =new string[] { "I", "want", "to", "sleep" };

            for (int i = 0; i < s.Length; i++)
            {
                System.Console.Out.Write(s[i] + " ");
            }

            foreach (string element in s)
            {
                System.Console.Out.Write(element + " ");
            }

            IWebDriver driver = null;
            int attempt = 0;
            while (driver.FindElements(By.Id("test")).Count==0 && attempt<60)  // Count - показывает количество найденных элементов
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }

            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60)  
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }

            do         // При использовании  Do While тело цикла выполниться хотя бы один раз при любых случаях 
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;

            } while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60);
        }
    }
}
