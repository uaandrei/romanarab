using System.Linq;
using System.Collections.Generic;

namespace RomanNumbersCalculator.BL
{
    public class RomanStringParser
    {
        private List<string> _listOfUnitNumbers;
        private List<string> _listOfTenNumbers;
        private List<string> _listOfHundredNumbers;
        private List<string> _listOfThousandsNumbers;

        public RomanStringParser()
        {
            var romanNumbersGenerator = new RomanNumbersGenerator();
            _listOfUnitNumbers = romanNumbersGenerator.GenerateRomanUnits();
            _listOfUnitNumbers.Reverse();
            _listOfTenNumbers = romanNumbersGenerator.GenerateRomanTens();
            _listOfTenNumbers.Reverse();
            _listOfHundredNumbers = romanNumbersGenerator.GenerateRomanHundreds();
            _listOfHundredNumbers.Reverse();
            _listOfThousandsNumbers = romanNumbersGenerator.GenerateRomanThousands();
            _listOfThousandsNumbers.Reverse();
        }

        public List<string> Parse(string romanString)
        {
            var listOfUnits = new List<string>();
            var firstFoundRomanNumberIndex = int.MaxValue;
            var indexesAndNumbers = new Dictionary<int, string>();

            while (true)
            {
                indexesAndNumbers.Clear();
                TryToAddKeyValuePairToDictionary(GetFirstIndexAndFoundNumberInString(romanString, _listOfUnitNumbers), indexesAndNumbers);
                TryToAddKeyValuePairToDictionary(GetFirstIndexAndFoundNumberInString(romanString, _listOfTenNumbers), indexesAndNumbers);
                TryToAddKeyValuePairToDictionary(GetFirstIndexAndFoundNumberInString(romanString, _listOfHundredNumbers), indexesAndNumbers);
                TryToAddKeyValuePairToDictionary(GetFirstIndexAndFoundNumberInString(romanString, _listOfThousandsNumbers), indexesAndNumbers);

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
