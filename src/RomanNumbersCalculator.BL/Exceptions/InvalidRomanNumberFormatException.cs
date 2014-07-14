using System;

namespace RomanNumbersCalculator.BL.Exceptions
{
    public class InvalidRomanNumberFormatException : Exception
    {
        public InvalidRomanNumberFormatException(string message)
            : base(message)
        {

        }
    }
}
