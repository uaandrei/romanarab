using System;

namespace RomanNumbersCalculator.BL.NumberExceptions
{
    public class InvalidNumberException : Exception
    {
        public InvalidNumberException(string message)
            : base(message)
        {

        }
    }
}
