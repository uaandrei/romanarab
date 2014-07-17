using System.Collections.Generic;

namespace RomanNumbersCalculator.BL
{
    public class RomanStringParser
    {
        private List<string> _romanUnitsList;

        public RomanStringParser(RomanSymbolsGroup romanSymbolsGroup)
        {
            var romanNumbersGenerator = new RomanNumbersGenerator();
            _romanUnitsList = romanNumbersGenerator.GenerateRomanNumbers(romanSymbolsGroup);
            _romanUnitsList.Reverse();
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
                foreach (var romanUnit in _romanUnitsList)
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
