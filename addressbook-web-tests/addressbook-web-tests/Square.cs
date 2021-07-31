using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace addressbook_web_tests
{
    class Square : Figure
    {
        private int size;


        public Square(int size)
        {
            this.size = size;
        }
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }



        /*public int getSize()
        {
            return size;
        }

        public void setSize(int size)
        {
            this.size = size;
        }*/
    }
}
