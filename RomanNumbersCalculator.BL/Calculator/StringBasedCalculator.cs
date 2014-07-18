using System.Collections.Generic;
namespace RomanNumbersCalculator.BL.Calculator
{
    public class StringBasedCalculator : ICalculator<string>
    {
        private List<string> _axisOfSymbols;

        public StringBasedCalculator(List<string> listOfSymbols)
        {
            _axisOfSymbols = listOfSymbols;
        }

        public string Add(string value1, string value2, out bool hasTransport)
        {
            hasTransport = false;
            var indexOfResult = _axisOfSymbols.IndexOf(value1) + _axisOfSymbols.IndexOf(value2);
            if (indexOfResult >= _axisOfSymbols.Count)
            {
                indexOfResult -= _axisOfSymbols.Count;
                hasTransport = true;
            }
            return _axisOfSymbols[indexOfResult];
        }
    }
}
