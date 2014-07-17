using System.Collections.Generic;

namespace RomanNumbersCalculator.BL.Specification
{
    public class SymbolLimitInString : ISpecification<string>
    {
        private string _symbol;
        private int _limit;

        public SymbolLimitInString(string symbol, int limit)
        {
            _symbol = symbol;
            _limit = limit;
        }

        public bool IsSatisfiedBy(string candidate)
        {
            var occurrences = 0;
            while (candidate.Contains(_symbol))
            {
                var startingIndexOfSymbolInCandidate = candidate.IndexOf(_symbol);
                candidate = candidate.Remove(startingIndexOfSymbolInCandidate, _symbol.Length);
                ++occurrences;
            }
            return occurrences <= _limit;
        }
    }
}
