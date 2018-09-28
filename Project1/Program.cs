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
        interface IReadable
        {
            List<int> Read();  //List<Current>
        }

        static void Main(string[] args)
        {
            Currency Cur1 = new Currency(3444, "Hrivnia");
            Cur1.Print();

            List<Currency> CurrencyList = new List<Currency>();

            using (StreamReader str = new StreamReader("currencies.txt",
                                    Encoding.Default))
            {
                while (!str.EndOfStream)
                {
                    string current_currency = str.ReadLine();
                    CurrencyList.Add(new Currency(int.Parse(current_currency.Split(new char[] { ' ' })[0]),
                        current_currency.Split(new char[] { ' ' })[1]));
                }
            }

            foreach (Currency p in CurrencyList)
            {
                Console.WriteLine(p);
            }

            Console.ReadKey();
        }
    }
}
