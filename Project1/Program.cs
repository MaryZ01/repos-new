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
                c.Print();

            //Console.WriteLine("Write only UAH currencies: ");
            //Cur1.ChooseUAH(CurrencyList);
            
            Console.WriteLine("\nConverting to dictionary.");
            Dictionary<double, currency> CurrencyDictionary = Cur1.ConvertToDictionary(CurrencyList);

            //запис в файл
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "WRITE_DICTIONARY.txt")))
            {
                foreach (var dict in CurrencyDictionary)
                    outputFile.WriteLine(dict);
            }


                Console.ReadKey();
        }
    }
}
