﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;
using RomanNumbersCalculator.BL.Specification;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanSymbolLimitInStringTests
    {
        [TestMethod]
        public void IsSatisfiedBy_Should_ReturnTrue_WhenPassedStringContains3OrLessOfTheSymbolSpecified()
        {
            var specifiedSymbol = "I";
            var romanSymbolLimitInString = new SymbolLimitInString(specifiedSymbol, 3);
            var romanString = "MMXXVIII";

            Assert.IsTrue(romanSymbolLimitInString.IsSatisfiedBy(romanString));
        }

        [TestMethod]
        public void IsSatisfiedBy_Should_ReturnFalse_WhenPassedStringContainsMoreThan3OfTheSymbolSpecified()
        {
            var specifiedSymbol = "I";
            var romanSymbolLimitInString = new SymbolLimitInString(specifiedSymbol, 3);
            var romanString = "MMXXVIIII";

            Assert.IsFalse(romanSymbolLimitInString.IsSatisfiedBy(romanString));
        }
    }
}
