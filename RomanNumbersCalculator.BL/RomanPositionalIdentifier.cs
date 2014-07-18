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
            _listOfUnitNumbers = romanNumbersGenerator.GenerateRomanUnits();
            _listOfTenNumbers = romanNumbersGenerator.GenerateRomanTens();
            _listOfHundredNumbers = romanNumbersGenerator.GenerateRomanHundreds();
            _listOfThousandsNumbers = romanNumbersGenerator.GenerateRomanThousands();
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
