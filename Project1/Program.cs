using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


namespace Project1
{
    class Program
    {

        static void Main(string[] args)
        {
            Currency Cur1 = new Currency(3444, "Hrivnia");
            Cur1.Print();

            Cur1.Read("currencies.txt");


            Console.ReadKey();
        }
    }
}
