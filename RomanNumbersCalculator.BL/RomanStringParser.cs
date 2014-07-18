using System.Linq;
using System.Collections.Generic;

namespace RomanNumbersCalculator.BL
{
    public class RomanStringParser
    {
        private List<string> _reversedListOfUnitNumbers;
        private List<string> _reversedListOfTenNumbers;
        private List<string> _reversedListOfHundredNumbers;
        private List<string> _reversedListOfThousandsNumbers;

        public RomanStringParser()
        {
            _reversedListOfUnitNumbers = new List<string>(RomanNumbersContainer.Instance.Units);
            _reversedListOfUnitNumbers.Reverse();
            _reversedListOfTenNumbers = new List<string>(RomanNumbersContainer.Instance.Tens);
            _reversedListOfTenNumbers.Reverse();
            _reversedListOfHundredNumbers = new List<string>(RomanNumbersContainer.Instance.Hundreds);
            _reversedListOfHundredNumbers.Reverse();
            _reversedListOfThousandsNumbers = new List<string>(RomanNumbersContainer.Instance.Thousands);
            _reversedListOfThousandsNumbers.Reverse();
        }

        public List<string> Parse(string romanString)
        {
            var listOfUnits = new List<string>();
            var firstFoundRomanNumberIndex = int.MaxValue;
            var indexesAndNumbers = new Dictionary<int, string>();

            while (true)
            {
                indexesAndNumbers.Clear();
                TryToAddKeyValuePairToDictionary(GetFirstIndexAndFoundNumberInString(romanString, _reversedListOfUnitNumbers), indexesAndNumbers);
                TryToAddKeyValuePairToDictionary(GetFirstIndexAndFoundNumberInString(romanString, _reversedListOfTenNumbers), indexesAndNumbers);
                TryToAddKeyValuePairToDictionary(GetFirstIndexAndFoundNumberInString(romanString, _reversedListOfHundredNumbers), indexesAndNumbers);
                TryToAddKeyValuePairToDictionary(GetFirstIndexAndFoundNumberInString(romanString, _reversedListOfThousandsNumbers), indexesAndNumbers);

                firstFoundRomanNumberIndex = indexesAndNumbers.Min(p => p.Key);

                var hasFoundRomanUnit = firstFoundRomanNumberIndex != int.MaxValue;
                if (hasFoundRomanUnit)
                {
                    romanString = romanString.Remove(firstFoundRomanNumberIndex, indexesAndNumbers[firstFoundRomanNumberIndex].Length);
                    listOfUnits.Add(indexesAndNumbers[firstFoundRomanNumberIndex]);
                }
                else
                {
                    break;
                }

            }

            return listOfUnits;
        }

        private KeyValuePair<int, string> GetFirstIndexAndFoundNumberInString(string romanString, List<string> listOfRomanNumbers)
        {
            var indexOfFirstNumber = int.MaxValue;
            var firstRomanNumber = string.Empty;
            foreach (var romanNumber in listOfRomanNumbers)
            {
                if (romanString.Contains(romanNumber))
                {
                    var indexOfCurrentRomanNumberString = romanString.IndexOf(romanNumber);
                    if (indexOfCurrentRomanNumberString < indexOfFirstNumber)
                    {
                        indexOfFirstNumber = indexOfCurrentRomanNumberString;
                        firstRomanNumber = romanNumber;
                    }
                }
            }
            return new KeyValuePair<int, string>(indexOfFirstNumber, firstRomanNumber);
        }

        private void TryToAddKeyValuePairToDictionary(KeyValuePair<int, string> keyValue, Dictionary<int, string> dictionary)
        {
            if (dictionary.ContainsKey(keyValue.Key))
                return;
            dictionary.Add(keyValue.Key, keyValue.Value);
        }
    }
}
