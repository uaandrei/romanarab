using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanNumbersGeneratorTest
    {
        private RomanNumbersGenerator _romanNumbersGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _romanNumbersGenerator = new RomanNumbersGenerator();
        }

        [TestMethod]
        public void GenerateRomanNumbers_Should_GenerateAllUnitsRomanNumbers_When_IVX_RomanGroupIsPassed()
        {
            var romanUnitsSymbolsGroup = new RomanSymbolsGroup("I", "V", "X");

            var actualRomanNumbers = _romanNumbersGenerator.GenerateRomanNumbers(romanUnitsSymbolsGroup);

            var expectedRomanNumbers = new[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }

        [TestMethod]
        public void GenerateRomanNumbers_Should_GenerateAllTensRomanNumbers_When_XLC_RomanGroupIsPassed()
        {
            var romanTensSymbolsGroup = new RomanSymbolsGroup("X", "L", "C");

            var actualRomanNumbers = _romanNumbersGenerator.GenerateRomanNumbers(romanTensSymbolsGroup);

            var expectedRomanNumbers = new[] { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }

        [TestMethod]
        public void GenerateRomanNumbers_Should_GenerateAllThousandsRomanNumbers_When_XLC_RomanGroupIsPassed()
        {
            var romanThousandsSymbolsGroup = new RomanSymbolsGroup("C", "D", "M");

            var actualRomanNumbers = _romanNumbersGenerator.GenerateRomanNumbers(romanThousandsSymbolsGroup);

            var expectedRomanNumbers = new[] { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };

            for (int i = 0; i < expectedRomanNumbers.Length; i++)
            {
                Assert.AreEqual(expectedRomanNumbers[i], actualRomanNumbers[i]);
            }
        }
    }
}
