using System;

namespace CommonLibrary
{
    public class InvalidNumberException : Exception
    {
        public InvalidNumberException(string message)
            : base(message)
        {

        }
    }
}
