using COMM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCOMM_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(RadomChar.GetRandomint(1,100).ToString());
                //Console.WriteLine(RadomChar.GetRandomString(3, 10, true));
            }
          
            Console.ReadKey();
        }
    }
}
