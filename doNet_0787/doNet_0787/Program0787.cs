﻿using System;
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
        static partial void Welcome5626();//batchi function

        private static void Welcome0787()//lea fuction
        {
            Console.WriteLine("Enter your name: ");
            Console.WriteLine("pleas! ");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
    }
}

