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
            Currency Cur1 = new Currency(100, currency.USD);

            List<Currency> CurrencyList = new List<Currency>();
            Cur1.Read("currencies.txt", CurrencyList);
            foreach (var c in CurrencyList)
            {
                c.Print();
            }


            Console.ReadKey();
        }
    }
}
