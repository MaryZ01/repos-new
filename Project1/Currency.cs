using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Reflection;

namespace Project1
{
    /// <summary>  
    /// Interface which realises method Read(), which read data feom the file.  
    /// </summary>  
    public interface IRead
    {
        bool Read(string name, List<Currency> currency_list);                   //?? is_write
    }

    //Для перетворення enum в string
    //Створюєм атрибут під назвою "StringValue", який можна налаштовувати
    public class StringValue : System.Attribute
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }
    //Добавляємо атрибут "StringValue" в enum
    public enum currency
    {
        [StringValue("USD")]
        USD = 1,
        [StringValue("UAH")]
        UAH = 2,
        [StringValue("EUR")]
        EUR = 3,
        [StringValue("JPY")]
        JPY = 4
    }
    //клас з допомогою якого ми зможемо отримувати що потрібно
    public static class StringEnum
    {
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs = fi.GetCustomAttributes(typeof(StringValue), 
                false) as StringValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }

    /// <summary>  
    ///  Клас описує сутність Currency
    /// </summary> 
    public class Currency : IRead, IEnumerable<int>
    {
        ///<value am = "Ammount">Сума</value>
        ///<value cn = "CurrencyName">Назва валюти</value>
        public double Ammount { get; set; }
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
        public Currency(double ammnt, currency cur_name)
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

        public bool Read(string name, List<Currency> currency_list)
        {
            try
            {
                using (StreamReader str = new StreamReader((string)name, Encoding.Default))
                {
                    while (!str.EndOfStream)
                    {
                        string current_currency = str.ReadLine();
                        currency_list.Add(new Currency(double.Parse(current_currency.Split(new char[] { ' ' })[0]),
                           (currency)Enum.Parse(typeof(currency), current_currency.Split(new char[] { ' ' })[1])));
                    }

                    ///< returns nm = "CurrencyList" >Повертає список з прочитаними з файлу елементами</returns>
                    return true;
                }
            }
            catch(Exception ex)
            {
                string mess_ = string.Format("Unpredictable error: {0}\n", ex.Message);
                Console.WriteLine(mess_);
                return false;
            }
            finally
            {
                Console.WriteLine("Reading the file finished.\n");
            }
            
        }

        //public void ChooseUAH(List<Currency> cur_list)
        //{
        //    List<Currency> UAH_cur_list = new List<Currency>();
        //    foreach (var cur in cur_list)
        //    {
        //        if (cur.CurrencyName == currency.UAH)
        //            Console.WriteLine(cur.ToString());
        //    }

        //}

        public Dictionary<double, currency> ConvertToDictionary(List<Currency> cur_lst)
        {           
            Dictionary<double, currency> dict = new Dictionary<double, currency>();

            for (int i = 0; i < cur_lst.Count; i++)
            {
                dict.Add(cur_lst[i].Ammount, cur_lst[i].CurrencyName);
            }

            Console.WriteLine("\nConverting completed");
            return dict;
        }

        public IEnumerator<Currency> GetEnumerator()
        {
            Currency Cur = new Currency();
            for (int i = 0; i < 10; i++)
            {
                yield return Cur;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
