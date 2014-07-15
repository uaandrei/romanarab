using RomanNumbersCalculator.BL.Exceptions;
using System;

namespace RomanNumbersCalculator.BL
{
    public class RomanArabicConverter
    {
        private int[] _arabNumbers;
        private string[] _romanNumbers;

        public RomanArabicConverter()
        {
            InitializeArabRomanNumbers();
        }

        public int ToArabic(string romanValue)
        {
            throw new NotImplementedException();
        }

        public string ToRoman(int arabicValue)
        {
            if (arabicValue < 1)
                throw new ArabicNumberOutOfRomanNumberRangeException(arabicValue);
            if (arabicValue > 3999)
                throw new ArabicNumberOutOfRomanNumberRangeException(arabicValue);

            var romanNumber = string.Empty;

            var remainingArabicNumber = arabicValue;

            for (int i = 0; i < _arabNumbers.Length; i++)
            {
                while (remainingArabicNumber >= _arabNumbers[i])
                {
                    romanNumber += _romanNumbers[i];
                    remainingArabicNumber -= _arabNumbers[i];
                }
            }

            return romanNumber;
        }

        private void InitializeArabRomanNumbers()
        {
            _arabNumbers = new[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            _romanNumbers = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        }
    }
}
