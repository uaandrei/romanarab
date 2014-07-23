using Infrastructure;
using System.Text.RegularExpressions;

namespace NumbersCalculator.BL.NumberValidator
{
    public class ArabNumberValidator : ISpecification<string>
    {
        private const string ArabNumberPattern = @"^[0-3]?\d{0,3}$";
        private Regex _regex;

        public ArabNumberValidator()
        {
            _regex = new Regex(ArabNumberPattern);
        }

        public bool IsSatisfiedBy(string candidate)
        {
            return _regex.IsMatch(candidate);
        }
    }
}
