using System;

namespace RomanNumbersCalculator.BL.Exceptions
{
    public class ArabicNumberOutOfRomanNumberRangeException : Exception
    {
        private const string ValueOutsideOfRomanNumberRange = "Value {0} is outside roman number range 1 - 3999";

        public ArabicNumberOutOfRomanNumberRangeException(int arabicValue)
            : base(string.Format(ValueOutsideOfRomanNumberRange, arabicValue))
        {
        }
    }
}
