using RomanNumbersCalculator.BL.NumberProvider;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumbersCalculator.BL.NumberProvider
{
    public class RomanNumbersProvider : INumberProvider
    {
        private List<string> _romanUnits;
        private List<string> _romanTens;
        private List<string> _romanHundreds;
        private List<string> _romanThousands;

        public List<string> Units { get { return _romanUnits; } }
        public List<string> Tens { get { return _romanTens; } }
        public List<string> Hundreds { get { return _romanHundreds; } }
        public List<string> Thousands { get { return _romanThousands; } }
        public string ZeroValue { get { return string.Empty; } }

        public RomanNumbersProvider()
        {
            _romanUnits = GenerateRomanNumbers(RomanSymbolsGroup.UnitsGroup);
            _romanTens = GenerateRomanNumbers(RomanSymbolsGroup.TensGroup);
            _romanHundreds = GenerateRomanNumbers(RomanSymbolsGroup.HundredsGroup);
            _romanThousands = new List<string> { "M", "MM", "MMM" };

        }

        private List<string> GenerateRomanNumbers(RomanSymbolsGroup romanNumbersGroup)
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

        private IEnumerable<string> GetNextThreeNumbersStartingFrom(string startingValue, string incrementValue)
        {
            for (int i = 1; i <= 3; i++)
            {
                yield return startingValue + string.Concat(Enumerable.Repeat(incrementValue, i));
            }
        }
    }
}