using Infrastructure;
using Microsoft.Practices.Unity;
using RomanNumbersCalculator.BL.NumberProvider;
using RomanNumbersCalculator.BL.PositionalExtractor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumbersCalculator.BL.Calculator
{
    public class RomanNumberCalculator : INumberCalculator
    {
        private INumberProvider _numbersProvider;
        private Dictionary<IPositionalExtractor, StringBasedCalculator> _positionalAndCalculatorDictionary;

        public RomanNumberCalculator()
        {
            _numbersProvider = new RomanNumbersProvider();
            _positionalAndCalculatorDictionary = new Dictionary<IPositionalExtractor, StringBasedCalculator>();
            _positionalAndCalculatorDictionary.Add(new RomanPositionalExtractor(_numbersProvider.Units, "", "IV"),
                                                   new StringBasedCalculator(new[] { "" }.Concat(_numbersProvider.Units).ToList()));
            _positionalAndCalculatorDictionary.Add(new RomanPositionalExtractor(_numbersProvider.Tens, "IX", "XL"),
                                                   new StringBasedCalculator(new[] { "" }.Concat(_numbersProvider.Tens).ToList()));
            _positionalAndCalculatorDictionary.Add(new RomanPositionalExtractor(_numbersProvider.Hundreds, "XC", "CD"),
                                                   new StringBasedCalculator(new[] { "" }.Concat(_numbersProvider.Hundreds).ToList()));
            _positionalAndCalculatorDictionary.Add(new RomanPositionalExtractor(_numbersProvider.Thousands, "CM", ""),
                                                   new StringBasedCalculator(new[] { "" }.Concat(_numbersProvider.Thousands).ToList()));
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
