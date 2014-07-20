using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumbersCalculator.BL.PositionalExtractor
{
    public class ArabPositionalExtractor : IPositionalExtractor
    {
        private readonly int _position;

        public ArabPositionalExtractor(int position)
        {
            _position = position;
        }

        public string Extract(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "0";
            }
            if (_position >= value.Length)
            {
                return "0";
            }
            return value[value.Length - 1 - _position].ToString();
        }
    }
}
