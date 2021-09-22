using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class Test_If_then_else_
    {
        [Test]
        public void TestMethod()
        {
            double total=123;
            bool vipClient = true;
            if (total > 1000 || vipClient)
            {
                total = total * 0.9;
                System.Console.Out.Write("Скидка 10%, общая сумма равна "+ total);
            }
            else
            {

               System.Console.Out.Write("Скидки нет, общая сумма равна " + total);
            }
        }
    }
}
