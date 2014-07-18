using RomanNumbersCalculator.BL.Specification;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumbersCalculator.BL.RomanNumberSpecification
{
    public class ConsecutiveRomanPositionalsMustBeDescending : ISpecification<string>
    {
        private RomanStringParser _romanStringParser;
        private List<string> _listOfUnitNumbers;
        private List<string> _listOfTenNumbers;
        private List<string> _listOfHundredNumbers;
        private List<string> _listOfThousandsNumbers;

        public ConsecutiveRomanPositionalsMustBeDescending()
        {
            var romanNumbersGenerator = new RomanNumbersGenerator();
            _listOfUnitNumbers = romanNumbersGenerator.GenerateRomanUnits();
            _listOfTenNumbers = romanNumbersGenerator.GenerateRomanTens();
            _listOfHundredNumbers = romanNumbersGenerator.GenerateRomanHundreds();
            _listOfThousandsNumbers = romanNumbersGenerator.GenerateRomanThousands();
            _romanStringParser = new RomanStringParser();
        }

        public bool IsSatisfiedBy(string candidate)
        {
            var romanPositionalList = new List<RomanPositionalCategory>();

            var numbers = _romanStringParser.Parse(candidate);
            foreach (var number in numbers)
            {
                if (_listOfUnitNumbers.Contains(number))
                {
                    romanPositionalList.Add(RomanPositionalCategory.Units);
                }
                else if (_listOfTenNumbers.Contains(number))
                {
                    romanPositionalList.Add(RomanPositionalCategory.Tens);
                }
                else if (_listOfHundredNumbers.Contains(number))
                {
                    romanPositionalList.Add(RomanPositionalCategory.Hundreds);
                }
                else if (_listOfThousandsNumbers.Contains(number))
                {
                    romanPositionalList.Add(RomanPositionalCategory.Thousands);
                }
            }

            var sortedRomanPositionalList = romanPositionalList.Select(p => p).OrderBy(p => p).ToList();
            for (int i = 0; i < sortedRomanPositionalList.Count; i++)
            {
                if (romanPositionalList[i] != sortedRomanPositionalList[i])
                    return false;
            }

            return true;
        }

        private enum RomanPositionalCategory
        {
            Thousands,
            Hundreds,
            Tens,
            Units
        }
    }
}
