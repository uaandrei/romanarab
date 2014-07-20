using System.Text.RegularExpressions;
namespace RomanNumbersCalculator.BL.RomanNumberSpecification
{
    public class RomanNumberValidator : ISpecification<string>
    {
        private const string RomanNumberPattern = "^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        private Regex _regex;

        public RomanNumberValidator()
        {
            _regex = new Regex(RomanNumberPattern);
        }

        public bool IsSatisfiedBy(string candidate)
        {
            return _regex.IsMatch(candidate);
        }
    }
}
