using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanNumbersContainerTests
    {
        [TestMethod]
        public void GenerateRomanUnits_ReturnsAllRomanUnits()
        {
            var actualRomanNumbers = RomanNumbersContainer.Instance.Units;

            var expectedRomanNumbers = new[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }

        [TestMethod]
        public void GenerateRomanTens_ReturnsAllRomanTens()
        {
            var actualRomanNumbers = RomanNumbersContainer.Instance.Tens;

            var expectedRomanNumbers = new[] { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }

        [TestMethod]
        public void GenerateRomanHundreds_ReturnsAllRomanHundreds()
        {
            var actualRomanNumbers = RomanNumbersContainer.Instance.Hundreds;

            var expectedRomanNumbers = new[] { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }
    }
}
