using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersCalculator.BL.NumberProvider;

namespace CalculatorModule.Tests
{
    [TestClass]
    public class RomanNumbersProviderTests
    {
        private RomanNumbersProvider _romanNumbersContainer = new RomanNumbersProvider();

        [TestMethod]
        public void GenerateRomanUnits_ReturnsAllRomanUnits()
        {
            var actualRomanNumbers = _romanNumbersContainer.Units;

            var expectedRomanNumbers = new[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }

        [TestMethod]
        public void GenerateRomanTens_ReturnsAllRomanTens()
        {
            var actualRomanNumbers = _romanNumbersContainer.Tens;

            var expectedRomanNumbers = new[] { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }

        [TestMethod]
        public void GenerateRomanHundreds_ReturnsAllRomanHundreds()
        {
            var actualRomanNumbers = _romanNumbersContainer.Hundreds;

            var expectedRomanNumbers = new[] { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }
    }
}
