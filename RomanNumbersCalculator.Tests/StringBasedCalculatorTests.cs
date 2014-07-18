using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL.Calculator;
using System.Collections.Generic;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class StringBasedCalculatorTests
    {
        private StringBasedCalculator _stringBasedCalculator;
        private List<string> _symbolList;

        [TestInitialize]
        public void TestInitialize()
        {
            _symbolList = new List<string> { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            _stringBasedCalculator = new StringBasedCalculator(_symbolList);
        }

        [TestMethod]
        public void Add_Returns9thSymbolWithNoTransport_When_Adding3rdSymbolWith6th_AndTransportIsFalse()
        {
            var symbol1 = _symbolList[3];
            var symbol2 = _symbolList[6];
            bool hasTransport = false;

            var actual = _stringBasedCalculator.Add(symbol1, symbol2, ref hasTransport);
            var expected = _symbolList[9];

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(hasTransport);
        }

        [TestMethod]
        public void Add_Returns2ndSymbolWithTransport_When_Adding4thSymbolWith8th_AndTransportIsFalse()
        {
            var symbol1 = _symbolList[4];
            var symbol2 = _symbolList[8];
            bool hasTransport = false;

            var actual = _stringBasedCalculator.Add(symbol1, symbol2, ref hasTransport);
            var expected = _symbolList[2];

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(hasTransport);
        }

        [TestMethod]
        public void Add_Returns4thSymbolWithNoTransport_When_Adding1stSymbolWith2nd_AndTransportIsTrue()
        {
            var symbol1 = _symbolList[1];
            var symbol2 = _symbolList[2];
            bool hasTransport = true;

            var actual = _stringBasedCalculator.Add(symbol1, symbol2, ref hasTransport);
            var expected = _symbolList[4];

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(hasTransport);
        }
    }
}
