using System.Collections.Generic;
namespace RomanNumbersCalculator.BL
{
    public class RomanPositionalIdentifier
    {
        public bool IsFromUnits(string romanNumber)
        {
            return RomanNumbersContainer.Instance.Units.Contains(romanNumber);
        }

        public bool IsFromTens(string romanNumber)
        {
            return RomanNumbersContainer.Instance.Tens.Contains(romanNumber);
        }

        public bool IsFromHundreds(string romanNumber)
        {
            return RomanNumbersContainer.Instance.Hundreds.Contains(romanNumber);
        }

        public bool IsFromThousands(string romanNumber)
        {
            return RomanNumbersContainer.Instance.Thousands.Contains(romanNumber);
        }
    }
}
