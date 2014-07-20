using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersCalculator.BL.NumberValidator;

namespace CalculatorModule.Tests
{
    [TestClass]
    public class ArabNumberValidatorTests
    {
        private ArabNumberValidator _arabNumberValidator;

        [TestInitialize]
        public void TestInitialize()
        {
            _arabNumberValidator = new ArabNumberValidator();
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsTrue()
        {
            Assert.IsTrue(_arabNumberValidator.IsSatisfiedBy("0123"));
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsTrue_WhenMissingPositional()
        {
            Assert.IsTrue(_arabNumberValidator.IsSatisfiedBy("23"));
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsFalse()
        {
            Assert.IsFalse(_arabNumberValidator.IsSatisfiedBy("4000"));
        }
    }
}
