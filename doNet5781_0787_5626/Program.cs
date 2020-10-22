using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doNet5781_0787_5626
{
    class Program
    {
        static void Main(string[] args)
        {
           
            welcome5626();
            Console.ReadKey();

        }

        private static void welcome5626()
        {
            Console.WriteLine("Enter your name:");
            String name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }

    }
}