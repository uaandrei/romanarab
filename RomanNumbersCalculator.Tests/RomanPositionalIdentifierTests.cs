using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanPositionalIdentifierTests
    {
        private RomanPositionalIdentifier _romanPositionalIdentifier;

        [TestInitialize]
        public void TestInitialize()
        {
            _romanPositionalIdentifier = new RomanPositionalIdentifier();
        }


        [TestMethod]
        public void IsFromUnits_ReturnsTrue_When_CheckingAllRomanUnitNumbers()
        {
            var romanNumbers = new[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            foreach (var romanNumber in romanNumbers)
            {
                Assert.IsTrue(_romanPositionalIdentifier.IsFromUnits(romanNumber));
            }
        }

        [TestMethod]
        public void IsFromTens_ReturnsTrue_When_CheckingAllRomanTenNumbers()
        {
            var romanNumbers = new[] { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };

            foreach (var romanNumber in romanNumbers)
            {
                Assert.IsTrue(_romanPositionalIdentifier.IsFromTens(romanNumber));
            }
        }

        [TestMethod]
        public void IsFromHundreds_ReturnsTrue_When_CheckingAllRomanHundredNumbers()
        {
            var romanNumbers = new[] { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };

            foreach (var romanNumber in romanNumbers)
            {
                Assert.IsTrue(_romanPositionalIdentifier.IsFromHundreds(romanNumber));
            }
        }

        [TestMethod]
        public void IsFromThousands_ReturnsTrue_When_CheckingAllRomanThousandNumbers()
        {
            var romanNumbers = new[] { "M", "MM", "MMM" };

            foreach (var romanNumber in romanNumbers)
            {
                Assert.IsTrue(_romanPositionalIdentifier.IsFromThousands(romanNumber));
            }
        }
    }
}
