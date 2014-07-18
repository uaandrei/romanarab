using System.Collections.Generic;
namespace RomanNumbersCalculator.BL
{
    public class RomanPositionalIdentifier
    {
        private List<string> _listOfUnitNumbers;
        private List<string> _listOfTenNumbers;
        private List<string> _listOfHundredNumbers;
        private List<string> _listOfThousandsNumbers;

        public RomanPositionalIdentifier()
        {
            var romanNumbersGenerator = new RomanNumbersGenerator();
            _listOfUnitNumbers = romanNumbersGenerator.GenerateRomanNumbers(new RomanSymbolsGroup("I", "V", "X"));
            _listOfTenNumbers = romanNumbersGenerator.GenerateRomanNumbers(new RomanSymbolsGroup("X", "L", "C"));
            _listOfHundredNumbers = romanNumbersGenerator.GenerateRomanNumbers(new RomanSymbolsGroup("C", "D", "M"));
            _listOfThousandsNumbers = RomanNumbersGenerator.GenerateRomanThousands();
        }

        public bool IsFromUnits(string romanNumber)
        {
            return _listOfUnitNumbers.Contains(romanNumber);
        }

        public bool IsFromTens(string romanNumber)
        {
            return _listOfTenNumbers.Contains(romanNumber);
        }

        public bool IsFromHundreds(string romanNumber)
        {
            return _listOfHundredNumbers.Contains(romanNumber);
        }

        public bool IsFromThousands(string romanNumber)
        {
            return _listOfThousandsNumbers.Contains(romanNumber);
        }
    }
}
