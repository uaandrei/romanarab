using System.Collections.Generic;

namespace RomanNumbersCalculator.BL
{
    public class RomanStringParser
    {
        private List<string> _romanNumbersList;

        public RomanStringParser(RomanSymbolsGroup romanSymbolsGroup)
        {
            var romanNumbersGenerator = new RomanNumbersGenerator();
            _romanNumbersList = romanNumbersGenerator.GenerateRomanNumbers(romanSymbolsGroup);
            _romanNumbersList.Reverse();
        }

        public RomanStringParser(List<string> romanNumbers)
        {
            romanNumbers.Reverse();
            _romanNumbersList = romanNumbers;
        }

        public List<string> Parse(string romanString)
        {
            var listOfUnits = new List<string>();
            var hasFoundRomanUnit = false;
            var indexOfFirstRomanUnitInRomanString = int.MaxValue;
            var foundRomanUnit = string.Empty;

            do
            {
                hasFoundRomanUnit = false;
                foreach (var romanUnit in _romanNumbersList)
                {
                    if (romanString.Contains(romanUnit))
                    {
                        var indexOfCurrentRomanUnitInRomanString = romanString.IndexOf(romanUnit);
                        if (indexOfCurrentRomanUnitInRomanString < indexOfFirstRomanUnitInRomanString)
                        {
                            indexOfFirstRomanUnitInRomanString = indexOfCurrentRomanUnitInRomanString;
                            foundRomanUnit = romanUnit;
                        }
                        hasFoundRomanUnit = true;
                    }
                }
                if (hasFoundRomanUnit)
                {
                    romanString = romanString.Remove(indexOfFirstRomanUnitInRomanString, foundRomanUnit.Length);
                    listOfUnits.Add(foundRomanUnit);
                }
                indexOfFirstRomanUnitInRomanString = int.MaxValue;

            } while (hasFoundRomanUnit);

            return listOfUnits;
        }
    }
}
