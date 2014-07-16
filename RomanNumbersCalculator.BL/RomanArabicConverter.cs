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

        public int ToArabic(string romanNumber)
        {
            if (string.IsNullOrEmpty(romanNumber))
                throw new InvalidRomanNumberFormatException("Empty roman value.");

            romanNumber = romanNumber.ToUpper();
            var arabicNumberResult = 0;
            var characterIndex = 0;

            while (characterIndex < romanNumber.Length)
            {
                var romanLetter = romanNumber[characterIndex];
                var numberFromRomanLetter = GetNumberForLetter(romanLetter);

                if (numberFromRomanLetter < 0)
                    throw new InvalidRomanNumberFormatException(string.Format("Invalid roman number: ", romanLetter));

                characterIndex++;
                if (characterIndex == romanNumber.Length)
                {
                    arabicNumberResult += numberFromRomanLetter;
                }
                else
                {
                    var nextNumberFromRomanLetter = GetNumberForLetter(romanNumber[characterIndex]);

                    if (nextNumberFromRomanLetter > numberFromRomanLetter)
                    {
                        arabicNumberResult += (nextNumberFromRomanLetter - numberFromRomanLetter);
                        characterIndex++;
                    }
                    else
                    {
                        arabicNumberResult += numberFromRomanLetter;
                    }
                }

            }

            if (arabicNumberResult > 3999)
                throw new InvalidRomanNumberFormatException("Invalid roman number, value exceeds 3999");

            return arabicNumberResult;
        }

        public string ToRoman(int arabicNumber)
        {
            if (arabicNumber < 1)
                throw new ArabicNumberOutOfRomanNumberRangeException(arabicNumber);
            if (arabicNumber > 3999)
                throw new ArabicNumberOutOfRomanNumberRangeException(arabicNumber);

            var romanNumber = string.Empty;

            var remainingArabicNumber = arabicNumber;

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

        private int GetNumberForLetter(char letter)
        {
            switch (letter)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return -1;
            }
        }
    }
}
