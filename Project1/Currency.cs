﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project1
{

    public enum Koef {DOL, UAH,EUR }
    /// <summary>  
    ///  Інтерфейс з методом Read(), котрий зчитує дані з файлу.  
    /// </summary>  
    public interface IRead
    {
        List<Currency>Read(string name);
    }

    /// <summary>  
    ///  Клас описує сутність Currency що представляє собою 
    /// </summary> 
    public class Currency: IRead
    {
        ///<value am = "Ammount">Сума</value>
        ///<value cn = "CurrencyName">Назва валюти</value>
        public int Ammount { get; set; }
        public string CurrencyName { get; set; }        

        public Currency()
        {
            this.Ammount = 0;
            this.CurrencyName = "name";
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

        public List<Currency> Read(string name)
        {
           
            using (StreamReader str = new StreamReader(name, Encoding.Default))
            {
                List<Currency> CurrencyList = new List<Currency>();
                while (!str.EndOfStream)
                {
                    string current_currency = str.ReadLine();
                    CurrencyList.Add(new Currency(int.Parse(current_currency.Split(new char[] { ' ' })[0]),
                                        current_currency.Split(new char[] { ' ' })[1]));
                }

                ///< returns nm = "CurrencyList" >Повертає список з прочитаними з файлу елементами</returns>
                return CurrencyList;
              
            }
        }

        public void ConvertToDictionary()
        {
             List<Currency> CurrencyList = new List<Currency>();
             Dictionary<string, int> dict = new Dictionary<string, int>();

             for (int i = 0; i < CurrencyList.Count; i++)
             {
                 dict.Add(CurrencyList[i].CurrencyName,CurrencyList[i].Ammount);
             }
        }
    }
}
