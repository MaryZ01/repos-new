using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Project1
{
    [TestClass]
    public class CurrencyTests
    {
        [TestMethod]
        public void ConvertToDictionary_List_to_Dictionary_returned()
        {
            //arrange
            List<Currency> CurrencyList = new List<Currency>();
            Currency TestCur = new Currency(100, currency.EUR);
            CurrencyList.Add(TestCur);

            Dictionary<double, currency> ExpectedResultDict = new Dictionary<double, currency>();
            ExpectedResultDict.Add( 100, currency.EUR );

            //act
            Dictionary<double,currency>CurrentDict = TestCur.ConvertToDictionary(CurrencyList);

            //assert
            Assert.AreEqual(ExpectedResultDict, CurrentDict);

        }
    }
}
