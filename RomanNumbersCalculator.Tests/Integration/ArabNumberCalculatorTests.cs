using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersCalculator.BL.Calculator;

namespace CalculatorModule.Tests.Integration
{
    [TestClass]
    public class ArabNumberCalculatorTests
    {
        private ArabNumberCalculator _arabNumberCalculator;

        [TestInitialize]
        public void TestInitialize()
        {
            _arabNumberCalculator = new ArabNumberCalculator();
        }

        [TestMethod]
        public void Add_ReturnsCorrectValue()
        {
            var actual = _arabNumberCalculator.Add("1234", "321");
            Assert.AreEqual("1555", actual);
        }

        [TestMethod]
        public void Add_ReturnsCorrectValue2()
        {
            var actual = _arabNumberCalculator.Add("2567", "735");
            Assert.AreEqual("3302", actual);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Add_ThrowsException_When_ResultIsTooLarge()
        {
            var number1 = "3234";
            var number2 = "966";

            _arabNumberCalculator.Add(number1, number2);
            Assert.Fail("This test should fail when result is too large");
        }
    }
}
