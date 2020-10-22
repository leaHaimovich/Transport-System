using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doNet5781_00_0787_5626
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome0787();
            Welcome5626();
            Console.ReadKey();
        }
        static partial void Welcome5626();

        private static void Welcome0787()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
    }
}

