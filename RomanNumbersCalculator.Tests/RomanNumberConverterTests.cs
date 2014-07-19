using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;
using RomanNumbersCalculator.BL.NumberExceptions;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanNumberConverterTests
    {
        [TestMethod]
        public void ToRoman_Returns1666()
        {
            var actual = RomanNumberConverter.ToRoman("1666");
            var expected = "MDCLXVI";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ToArab_ReturnsMDCLXVI()
        {
            var actual = RomanNumberConverter.ToArab("MDCLXVI");
            var expected = "1666";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ToRoman_ReturnsMMMCDXLIV()
        {
            var actual = RomanNumberConverter.ToRoman("3444");
            var expected = "MMMCDXLIV";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ToArab_Returns3444()
        {
            var actual = RomanNumberConverter.ToArab("MMMCDXLIV");
            var expected = "3444";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberException))]
        public void ToArab_ThrowsException_When_NumberContainsInvalidCharacter()
        {
            RomanNumberConverter.ToArab("MMDCFII");
            Assert.Fail("Test should fail when roman string contains invalid number");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberException))]
        public void ToRoman_ThrowsException_When_ArabNumberIsTooBig()
        {
            RomanNumberConverter.ToArab("4000");
            Assert.Fail("Test should fail when arab number is too big");
        }
    }
}
