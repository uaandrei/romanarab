using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL.Calculator;
using RomanNumbersCalculator.BL.NumberProvider;
using System;

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
            var expected = "MMXXXIII";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_ReturnsCorectValue2()
        {
            var number1 = "MXL";
            var number2 = "CDIV";

            var actual = _romanNumberCalculator.Add(number1, number2);
            var expected = "MCDXLIV";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Add_ThrowsException_When_ResultIsTooLarge()
        {
            var number1 = "MMD";
            var number2 = "MD";

            _romanNumberCalculator.Add(number1, number2);
            Assert.Fail("This test should fail when second number has incorect format");
        }
    }
}
