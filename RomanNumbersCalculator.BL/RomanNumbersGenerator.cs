using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumbersCalculator.BL
{
    public class RomanNumbersGenerator
    {
        public List<string> GenerateRomanNumbers(RomanSymbolsGroup romanNumbersGroup)
        {
            var romanNumber = string.Empty;
            var romanNumbers = new List<string>();

            romanNumbers.AddRange(GetNextThreeNumbersStartingFrom(string.Empty, romanNumbersGroup.FirstNumber));
            romanNumbers.Add(romanNumbersGroup.FirstNumber + romanNumbersGroup.MiddleNumber);
            romanNumbers.Add(romanNumbersGroup.MiddleNumber);
            romanNumbers.AddRange(GetNextThreeNumbersStartingFrom(romanNumbersGroup.MiddleNumber, romanNumbersGroup.FirstNumber));
            romanNumbers.Add(romanNumbersGroup.FirstNumber + romanNumbersGroup.MaxNumber);

            return romanNumbers;
        }

        public static List<string> GenerateRomanThousands()
        {
            return new List<string> { "M", "MM", "MMM" };
        }

        private IEnumerable<string> GetNextThreeNumbersStartingFrom(string startingValue, string incrementValue)
        {
            for (int i = 1; i <= 3; i++)
            {
                yield return startingValue + string.Concat(Enumerable.Repeat(incrementValue, i));
            }
        }
    }
}