using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Currency
    {
        public int Ammount { get; set; }
        public string CurrencyName { get; set; }

        public Currency()
        {
            this.Ammount = 0;
            this.CurrencyName = "currency_name";
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

        public override string ToString()
        {
            return String.Format("Currency: \nAmmount: {0}\nName:    {1}\n",
                this.Ammount, this.CurrencyName);
        }

    }
}
