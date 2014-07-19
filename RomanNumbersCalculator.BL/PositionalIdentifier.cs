using RomanNumbersCalculator.BL.NumberProvider;

namespace RomanNumbersCalculator.BL
{
    public class PositionalIdentifier
    {
        private INumberProvider _numbersProvider;

        public PositionalIdentifier(INumberProvider numberProvider)
        {
            _numbersProvider = numberProvider;
        }

        public bool IsFromUnits(string number)
        {
            return _numbersProvider.Units.Contains(number);
        }

        public bool IsFromTens(string number)
        {
            return _numbersProvider.Tens.Contains(number);
        }

        public bool IsFromHundreds(string number)
        {
            return _numbersProvider.Hundreds.Contains(number);
        }

        public bool IsFromThousands(string number)
        {
            return _numbersProvider.Thousands.Contains(number);
        }
    }
}
