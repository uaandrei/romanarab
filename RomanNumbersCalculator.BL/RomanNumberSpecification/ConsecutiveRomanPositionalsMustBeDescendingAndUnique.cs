using RomanNumbersCalculator.BL.NumberProvider;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumbersCalculator.BL.RomanNumberSpecification
{
    public class ConsecutiveRomanPositionalsMustBeDescendingAndUnique : ISpecification<string>
    {
        private RomanStringParser _romanStringParser;
        private PositionalIdentifier _identifier;

        public ConsecutiveRomanPositionalsMustBeDescendingAndUnique()
        {
            _romanStringParser = new RomanStringParser();
            _identifier = new PositionalIdentifier(new RomanNumbersProvider());
        }

        public bool IsSatisfiedBy(string candidate)
        {
            var romanPositionalList = new List<RomanPositionalCategory>();

            var numbers = _romanStringParser.Parse(candidate);
            foreach (var number in numbers)
            {
                if (_identifier.IsFromUnits(number))
                {
                    romanPositionalList.Add(RomanPositionalCategory.Units);
                }
                else if (_identifier.IsFromTens(number))
                {
                    romanPositionalList.Add(RomanPositionalCategory.Tens);
                }
                else if (_identifier.IsFromHundreds(number))
                {
                    romanPositionalList.Add(RomanPositionalCategory.Hundreds);
                }
                else if (_identifier.IsFromThousands(number))
                {
                    romanPositionalList.Add(RomanPositionalCategory.Thousands);
                }
            }

            var correctRomanPositionalList = new List<RomanPositionalCategory> { RomanPositionalCategory.Thousands, RomanPositionalCategory.Hundreds, RomanPositionalCategory.Tens, RomanPositionalCategory.Units };

            correctRomanPositionalList = correctRomanPositionalList.Intersect(romanPositionalList).ToList();

            if (romanPositionalList.Count != correctRomanPositionalList.Count)
                return false;

            for (int i = 0; i < correctRomanPositionalList.Count; i++)
            {
                if (romanPositionalList[i] != correctRomanPositionalList[i])
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
