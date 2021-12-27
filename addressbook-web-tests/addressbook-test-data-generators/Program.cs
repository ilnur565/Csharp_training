using System;
using System.IO;
using addressbook_web_tests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {

           
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(@"C:\Users\User\source\repos\Csharp_training\addressbook-web-tests\addressbook-web-tests\group.csv");
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(String.Format("${0},${1},${2}", 
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10)
                    ));
        }
        writer.Close();

        }
    }
}
    