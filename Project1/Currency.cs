using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project1
{
    public enum Koef {DOL, UAH,EUR }
    public interface IRead {
        void Read(string name);
    }
    public class Currency:IRead
    {
        public int Ammount { get; set; }
        public string CurrencyName { get; set; }
       public  List<Currency> CurrencyList = new List<Currency>();
        public Currency()
        {
            this.Ammount = 10;
            this.CurrencyName = "dolar";
        }

        public Currency(int ammnt, string cur_name)
        {
            this.Ammount = ammnt;
            this.CurrencyName = cur_name;
        }

        public void Print()
        {
            Console.WriteLine("Currency name: {0}", this.CurrencyName);
            Console.WriteLine("Ammount:       {0}", this.Ammount);
            Console.WriteLine();
        }
        public void ConvertTo(string val)
        {
            
        }
        public override string ToString()
        {
            return String.Format("Currency: \nAmmount: {0}\nName:    {1}\n",
                this.Ammount, this.CurrencyName);
        }
        public void Read(string name)
        {
           
            using (StreamReader str = new StreamReader(name,
                                    Encoding.Default))
            {
                while (!str.EndOfStream)
                {
                    string current_currency = str.ReadLine();
                    CurrencyList.Add(new Currency(int.Parse(current_currency.Split(new char[] { ' ' })[0]),
                                        current_currency.Split(new char[] { ' ' })[1]));
                }
                foreach (var c in CurrencyList)
                {
                    if(c.CurrencyName=="hrivnia")
                    Console.WriteLine(c);
                }
            }
        }
        public void ConvertToDictionary()
        {
            Dictionary<string, int> d = new Dictionary<string, int>();

            for (int i = 0; i < CurrencyList.Count; i++)
            {


                d.Add(CurrencyList[i].CurrencyName,CurrencyList[i].Ammount);
            }
        }
    }
}
