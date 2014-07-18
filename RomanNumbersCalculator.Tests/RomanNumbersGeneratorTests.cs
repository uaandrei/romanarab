using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanNumbersGeneratorTests
    {
        private RomanNumbersGenerator _romanNumbersGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _romanNumbersGenerator = new RomanNumbersGenerator();
        }

        [TestMethod]
        public void GenerateRomanUnits_ReturnsAllRomanUnits()
        {
            var actualRomanNumbers = _romanNumbersGenerator.GenerateRomanUnits();

            var expectedRomanNumbers = new[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }

        [TestMethod]
        public void GenerateRomanTens_ReturnsAllRomanTens()
        {
            var actualRomanNumbers = _romanNumbersGenerator.GenerateRomanTens();

            var expectedRomanNumbers = new[] { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }

        [TestMethod]
        public void GenerateRomanHundreds_ReturnsAllRomanHundreds()
        {
            var actualRomanNumbers = _romanNumbersGenerator.GenerateRomanHundreds();

            var expectedRomanNumbers = new[] { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }
    }
}
