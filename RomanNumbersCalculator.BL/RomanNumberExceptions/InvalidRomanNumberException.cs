using System;

namespace RomanNumbersCalculator.BL.RomanNumberExceptions
{
    public class InvalidRomanNumberException : Exception
    {
        public InvalidRomanNumberException(string message)
            : base(message)
        {

        }
    }
}
