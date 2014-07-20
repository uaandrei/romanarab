using RomanNumbersCalculator.BL.NumberProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumbersCalculator.BL.PositionalExtractor
{
    public class RomanPositionalExtractor : IPositionalExtractor
    {
        private List<string> _numberList;
        private readonly string RemoveException;
        private readonly string ExistException;

        public RomanPositionalExtractor(List<string> numberList, string removeException, string existException)
        {
            _numberList = numberList;
            RemoveException = removeException;
            ExistException = existException;
        }

        public string Extract(string value)
        {
            if (!string.IsNullOrEmpty(ExistException) && value.Contains(ExistException))
                return ExistException;

            if (!string.IsNullOrEmpty(RemoveException))
            {
                value = value.Replace(RemoveException, string.Empty);
            }
            return _numberList.Reverse<string>().FirstOrDefault(p => value.Contains(p)) ?? string.Empty;
        }
    }
}
