using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL.Calculator;
using RomanNumbersCalculator.BL.NumberExceptions;
using Microsoft.Practices.Unity;
using RomanNumbersCalculator.BL.StringNumberParser;
using RomanNumbersCalculator.BL.RomanNumberSpecification;
using RomanNumbersCalculator.BL.NumberProvider;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanNumberCalculatorTests
    {
        private NumberCalculator _romanNumberCalculator;

        [TestInitialize]
        public void TestInitialize()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IStringNumberParser, RomanStringParser>();
            unityContainer.RegisterType<ISpecification<string>, ConsecutiveRomanPositionalsMustBeDescendingAndUnique>();
            unityContainer.RegisterType<INumberProvider, RomanNumbersProvider>();
            _romanNumberCalculator = new NumberCalculator(unityContainer);
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
        [ExpectedException(typeof(InvalidNumberException))]
        public void Add_ThrowsException_When_FirstNumberHasIncorectFormat()
        {
            var number1 = "MXDXLIV";
            var number2 = "CDLXXXIX";

            var actual = _romanNumberCalculator.Add(number1, number2);
            Assert.Fail("This test should fail when first number has incorect format");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberException))]
        public void Add_ThrowsException_When_SecondNumberHasIncorectFormat()
        {
            var number1 = "MDXLIV";
            var number2 = "CDLXXXIXV";

            var actual = _romanNumberCalculator.Add(number1, number2);
            Assert.Fail("This test should fail when second number has incorect format");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Add_ThrowsException_When_ResultIsTooLarge()
        {
            var number1 = "MMD";
            var number2 = "MD";

            var actual = _romanNumberCalculator.Add(number1, number2);
            Assert.Fail("This test should fail when second number has incorect format");
        }
    }
}
