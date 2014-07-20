using Infrastructure;
using RomanNumbersCalculator.BL.NumberProvider;
using RomanNumbersCalculator.BL.PositionalExtractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumbersCalculator.BL.Calculator
{
    public class ArabNumberCalculator : INumberCalculator
    {
        private INumberProvider _numbersProvider;
        private Dictionary<IPositionalExtractor, StringBasedCalculator> _positionalAndCalculatorDictionary;

        public ArabNumberCalculator()
        {
            _numbersProvider = new ArabNumbersProvider();
            _positionalAndCalculatorDictionary = new Dictionary<IPositionalExtractor, StringBasedCalculator>();
            _positionalAndCalculatorDictionary.Add(new ArabPositionalExtractor(0),
                                                   new StringBasedCalculator(_numbersProvider.Units));
            _positionalAndCalculatorDictionary.Add(new ArabPositionalExtractor(1),
                                                   new StringBasedCalculator(_numbersProvider.Tens));
            _positionalAndCalculatorDictionary.Add(new ArabPositionalExtractor(2),
                                                   new StringBasedCalculator(_numbersProvider.Hundreds));
            _positionalAndCalculatorDictionary.Add(new ArabPositionalExtractor(3),
                                                   new StringBasedCalculator(_numbersProvider.Thousands));
        }

        public string Add(string number1, string number2)
        {
            var additionResult = string.Empty;
            bool hasTransport = false;

            foreach (var item in _positionalAndCalculatorDictionary)
            {
                var value1 = item.Key.Extract(number1);
                var value2 = item.Key.Extract(number2);
                additionResult = item.Value.Add(value1, value2, ref hasTransport) + additionResult;
            }
            if (hasTransport)
            {
                throw new OverflowException("Result is too big");
            }
            return additionResult;
        }
    }
}
