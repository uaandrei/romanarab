using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL.Calculator;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanNumberCalculatorTests
    {
        private RomanNumberCalculator _romanNumberCalculator;

        [TestInitialize]
        public void TestInitialize()
        {
            _romanNumberCalculator = new RomanNumberCalculator();
        }

        [TestMethod]
        public void Add_ReturnsCorectValue()
        {
            var number1 = "MDXLIV";
            var number2 = "CDLXXXIX";

            var actual = _romanNumberCalculator.Add(number1, number2);
            var expected = "MMLIII";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_ThrowsException_When_NumbersAreInIncorectFormat()
        {
        }

        [TestMethod]
        public void Add_ThrowsException_When_ResultIsTooLarge()
        {
        }
    }
}
