using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;
using RomanNumbersCalculator.BL.Specification;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanSymbolLimitInStringTests
    {
        [TestMethod]
        public void IsSatisfiedBy_ReturnsTrue_WhenPassedStringContains3OrLessOfTheSymbolSpecified()
        {
            var specifiedSymbol = "I";
            var romanSymbolLimitInString = new SymbolLimitInString(specifiedSymbol, 3);
            var romanString = "MMXXVIII";

            Assert.IsTrue(romanSymbolLimitInString.IsSatisfiedBy(romanString));
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsFalse_WhenPassedStringContainsMoreThan3OfTheSymbolSpecified()
        {
            var specifiedSymbol = "I";
            var romanSymbolLimitInString = new SymbolLimitInString(specifiedSymbol, 3);
            var romanString = "MMXXVIIII";

            Assert.IsFalse(romanSymbolLimitInString.IsSatisfiedBy(romanString));
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsTrue_WhenPassedStringContains1OrLessOfTheSymbolSpecified()
        {
            var specifiedSymbol = "V";
            var romanSymbolLimitInString = new SymbolLimitInString(specifiedSymbol, 1);
            var romanString = "MMCCXVI";

            Assert.IsTrue(romanSymbolLimitInString.IsSatisfiedBy(romanString));
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsFalse_WhenPassedStringContainsMoreThan1OfTheSymbolSpecified()
        {
            var specifiedSymbol = "V";
            var romanSymbolLimitInString = new SymbolLimitInString(specifiedSymbol, 1);
            var romanString = "MMCCXVIV";

            Assert.IsFalse(romanSymbolLimitInString.IsSatisfiedBy(romanString));
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsTrue_WhenPassedStringDoesntContainTheSymbolSpecified()
        {
            var specifiedSymbol = "V";
            var romanSymbolLimitInString = new SymbolLimitInString(specifiedSymbol, 1);
            var romanString = "MMCCXIII";

            Assert.IsTrue(romanSymbolLimitInString.IsSatisfiedBy(romanString));
        }
    }
}
