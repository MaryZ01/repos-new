using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Project1
{
    /// <summary>  
    /// Interface which realises method Read(), which read data feom the file.  
    /// </summary>  
    public interface IRead
    {
        List<Currency> Read(string name);
    }

    public enum currency
    {
        USD = 1,
        UAH = 2,
        EUR = 3,
        JPY = 4
    }

    /// <summary>  
    ///  Клас описує сутність Currency що представляє собою 
    /// </summary> 
    public class Currency//: IRead
    {
        ///<value am = "Ammount">Сума</value>
        ///<value cn = "CurrencyName">Назва валюти</value>
        public int Ammount { get; set; }
        public currency CurrencyName { get; set; }

        public Currency()
        {
            this.Ammount = 0;
            this.CurrencyName = currency.UAH;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Project1"/> class with specified ammnt, cur_name
        /// </summary>
        /// <param name="ammnt"></param>
        /// <param name="cur_name"></param>

        public Currency(int ammnt, currency cur_name)
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

        public List<Currency> Read(string name)
        {

            using (StreamReader str = new StreamReader((string)name, Encoding.Default))
            {
                List<Currency> CurrencyList = new List<Currency>();
                while (!str.EndOfStream)
                {
                    //string ValueOfCurrency = StringEnum.GetStringValue(currency.EUR);

                    string current_currency = str.ReadLine();
                    CurrencyList.Add(new Currency(int.Parse(current_currency.Split(new char[] { ' ' })[0]),

                       (currency)Enum.Parse(typeof(currency), current_currency.Split(new char[] { ' ' })[1])));


                }

                ///< returns nm = "CurrencyList" >Повертає список з прочитаними з файлу елементами</returns>
                return CurrencyList;

            }
        }

        //public void ConvertToDictionary()
        //{
        //    List<Currency> CurrencyList = new List<Currency>();
        //    Dictionary<string, int> dict = new Dictionary<string, int>();

        //    for (int i = 0; i < CurrencyList.Count; i++)
        //    {
        //        dict.Add(CurrencyList[i].CurrencyName, CurrencyList[i].Ammount);
        //    }
        //}
    }
}
