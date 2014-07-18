using RomanNumbersCalculator.BL.RomanNumberExceptions;
using RomanNumbersCalculator.BL.RomanNumberSpecification;

namespace RomanNumbersCalculator.BL.Calculator
{
    public class RomanNumberCalculator
    {
        private RomanNumberValidator _numberValidator;
        private RomanStringParser _parser;
        private RomanPositionalIdentifier _identifier;

        public RomanNumberCalculator()
        {
            _numberValidator = new RomanNumberValidator(new ConsecutiveRomanPositionalsMustBeDescendingAndUnique());
            _parser = new RomanStringParser();
            _identifier = new RomanPositionalIdentifier();
        }

        public string Add(string number1, string number2)
        {
            if (!_numberValidator.IsValid(number1))
            {
                throw new InvalidRomanNumberException("First number is invalid.");
            }
            if (!_numberValidator.IsValid(number2))
            {
                throw new InvalidRomanNumberException("Second number is invalid.");
            }

            var positionalNumbersForFirstNumber = _parser.Parse(number1); return "";
        }
    }
}
