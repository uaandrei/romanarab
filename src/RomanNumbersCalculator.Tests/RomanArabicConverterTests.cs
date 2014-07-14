using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;
using RomanNumbersCalculator.BL.Exceptions;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanArabicConverterTests
    {
        private RomanArabicConverter _romanArabicConverter = new RomanArabicConverter();

        [TestMethod]
        [ExpectedException(typeof(ArabicNumberOutOfRomanNumberRangeException))]
        public void ToRoman_ShouldThrow_ArabicNumberOutOfRomanNumberRangeException_When_Value_Is_LessThan1()
        {
            var arabicValue = 0;

            _romanArabicConverter.ToRoman(arabicValue);

            Assert.Fail("Test should fail when arabic value is less than 1.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArabicNumberOutOfRomanNumberRangeException))]
        public void ToRoman_ShouldThrow_ArabicNumberOutOfRomanNumberRangeException_When_Value_Is_GreaterThan3999()
        {
            var arabicValue = 4000;

            _romanArabicConverter.ToRoman(arabicValue);

            Assert.Fail("Test should fail when arabic value is greater than 3999.");
        }

        [TestMethod]
        public void ToRoman_ShouldReturn_XV_When_ValueIs_15()
        {
            var arabicValue = 15;

            var romanNumber = _romanArabicConverter.ToRoman(arabicValue);
            var expectedRomanNumber = "XV";

            Assert.AreEqual(expectedRomanNumber, romanNumber);
        }

        [TestMethod]
        public void ToRoman_ShouldReturn_MMXIV_When_ValueIs_2014()
        {
            var arabicValue = 2014;

            var romanNumber = _romanArabicConverter.ToRoman(arabicValue);
            var expectedRomanNumber = "MMXIV";

            Assert.AreEqual(expectedRomanNumber, romanNumber);
        }

        [TestMethod]
        public void ToRoman_ShouldReturn_MDCXCVIII_When_ValueIs_1698()
        {
            var arabicValue = 1698;

            var romanNumber = _romanArabicConverter.ToRoman(arabicValue);
            var expectedRomanNumber = "MDCXCVIII";

            Assert.AreEqual(expectedRomanNumber, romanNumber);
        }
    }
}
