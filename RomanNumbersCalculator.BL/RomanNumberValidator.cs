using RomanNumbersCalculator.BL.RomanNumberSpecification;

namespace RomanNumbersCalculator.BL
{
    public class RomanNumberValidator : IRomanNumberValidator
    {
        private ISpecification<string> _romanNumberSpecification;

        public RomanNumberValidator(ISpecification<string> romaNumberSpcification)
        {
            _romanNumberSpecification = romaNumberSpcification;
        }

        public bool IsValid(string romanNumberString)
        {
            return _romanNumberSpecification.IsSatisfiedBy(romanNumberString);
        }
    }
}
