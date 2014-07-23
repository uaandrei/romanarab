using Infrastructure;
using System.Collections.Generic;

namespace NumbersCalculator.BL.Calculator
{
    public class StringBasedCalculator : ICalculator<string>
    {
        private List<string> _axisOfSymbols;

        public StringBasedCalculator(List<string> listOfSymbols)
        {
            _axisOfSymbols = listOfSymbols;
        }

        public string Add(string value1, string value2, ref bool hasTransport)
        {
            var indexOfResult = _axisOfSymbols.IndexOf(value1) + _axisOfSymbols.IndexOf(value2);
            if (hasTransport)
            {
                indexOfResult++;
            }
            if (indexOfResult >= _axisOfSymbols.Count)
            {
                indexOfResult -= _axisOfSymbols.Count;
                hasTransport = true;
            }
            else
            {
                hasTransport = false;
            }
            return _axisOfSymbols[indexOfResult];
        }
    }
}
