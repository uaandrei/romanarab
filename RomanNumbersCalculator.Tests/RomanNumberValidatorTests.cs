using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanNumberValidatorTests
    {
        private RomanNumberValidator _romanNumberValidator;

        [TestInitialize]
        public void TestInitialize()
        {
            _romanNumberValidator = new RomanNumberValidator();
        }

        [TestMethod]
        public void Validate_ReturnsTrue_When_RomanStringIsCorrect()
        {
            var romanNumberString = "MMMCMD";
        }
    }
}
