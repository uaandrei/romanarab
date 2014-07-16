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
        public void ToRoman_ShouldThrowArabicNumberOutOfRomanNumberRangeException_When_ValueIsLessThan1()
        {
            var arabicNumber = 0;

            _romanArabicConverter.ToRoman(arabicNumber);

            Assert.Fail("Test should fail when arabic number is less than 1.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArabicNumberOutOfRomanNumberRangeException))]
        public void ToRoman_Should_ThrowArabicNumberOutOfRomanNumberRangeException_When_ValueIsGreaterThan3999()
        {
            var arabicNumber = 4000;

            _romanArabicConverter.ToRoman(arabicNumber);

            Assert.Fail("Test should fail when arabic number is greater than 3999.");
        }

        [TestMethod]
        public void ToRoman_Should_ReturnLXV_When_ValueIs65()
        {
            var arabicNumber = 65;

            var romanNumber = _romanArabicConverter.ToRoman(arabicNumber);
            var expectedRomanNumber = "LXV";

            Assert.AreEqual(expectedRomanNumber, romanNumber);
        }

        [TestMethod]
        public void ToRoman_Should_ReturnMMXIV_When_ValueIs2014()
        {
            var arabicNumber = 2014;

            var romanNumber = _romanArabicConverter.ToRoman(arabicNumber);
            var expectedRomanNumber = "MMXIV";

            Assert.AreEqual(expectedRomanNumber, romanNumber);
        }

        [TestMethod]
        public void ToRoman_Should_ReturnMDCXCVIII_When_ValueIs1698()
        {
            var arabicNumber = 1698;

            var romanNumber = _romanArabicConverter.ToRoman(arabicNumber);
            var expectedRomanNumber = "MDCXCVIII";

            Assert.AreEqual(expectedRomanNumber, romanNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumberFormatException))]
        public void ToArabic_Should_ThrowInvalidRomanNumberFormatException_When_ValueIsEmpty()
        {
            var romanNumber = string.Empty;

            var arabNumber = _romanArabicConverter.ToArabic(romanNumber);

            Assert.Fail("Test should fail when roman number is empty.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumberFormatException))]
        public void ToArabic_Should_ThrowInvalidRomanNumberFormatException_When_ValueContainsInvalidCharacter()
        {
            var invalidRomanNumber = "f";

            _romanArabicConverter.ToArabic(invalidRomanNumber);

            Assert.Fail("Test should fail when roman number contains invalid character.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumberFormatException))]
        public void ToArabic_Should_ThrowInvalidRomanNumberFormatException_When_ValueIsBiggerThan3999()
        {
            var romanNumber = "MMMM";

            _romanArabicConverter.ToArabic(romanNumber);

            Assert.Fail("Test should fail when roman number is bigger than 3999.");
        }

        [TestMethod]
        public void ToArabic_Should_Return65_When_ValueIsLXV()
        {
            var romanNumber = "LXV";
            var expectedArabicNumber = 65;

            var arabicNumber = _romanArabicConverter.ToArabic(romanNumber);

            Assert.AreEqual(expectedArabicNumber, arabicNumber);
        }

        [TestMethod]
        public void ToArabic_Should_Return2014_When_ValueIsMMIV()
        {
            var romanNumber = "MMXIV";
            var expectedArabicNumber = 2014;

            var arabicNumber = _romanArabicConverter.ToArabic(romanNumber);

            Assert.AreEqual(expectedArabicNumber, arabicNumber);
        }

        [TestMethod]
        public void ToArabic_Should_Return1698_When_ValueIsMDCXCVIII()
        {
            var romanNumber = "MDCXCVIII";
            var expectedArabicNumber = 1698;

            var arabicNumber = _romanArabicConverter.ToArabic(romanNumber);

            Assert.AreEqual(expectedArabicNumber, arabicNumber);
        }
    }
}
