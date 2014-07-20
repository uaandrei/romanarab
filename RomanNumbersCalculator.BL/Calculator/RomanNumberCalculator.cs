using CalculatorModule.BL.Calculator;
using CommonLibrary;
using Infrastructure;
using NumbersCalculator.BL.NumberProvider;
using NumbersCalculator.BL.PositionalExtractor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersCalculator.BL.Calculator
{
    public class RomanNumberCalculator : INumberCalculator
    {
        private INumberProvider _numbersProvider;
        private Dictionary<IPositionalExtractor, StringBasedCalculator> _positionalAndCalculatorDictionary;

        public RomanNumberCalculator()
        {
            _numbersProvider = new RomanNumbersProvider();
            _positionalAndCalculatorDictionary = new Dictionary<IPositionalExtractor, StringBasedCalculator>();
            _positionalAndCalculatorDictionary.Add(new RomanPositionalExtractor(_numbersProvider.Units, RomanExceptionsConstants.Empty, RomanExceptionsConstants.UnitsExists),
                                                   new StringBasedCalculator(new[] { RomanExceptionsConstants.Empty }.Concat(_numbersProvider.Units).ToList()));
            _positionalAndCalculatorDictionary.Add(new RomanPositionalExtractor(_numbersProvider.Tens, RomanExceptionsConstants.TensRemove, RomanExceptionsConstants.TensExists),
                                                   new StringBasedCalculator(new[] { RomanExceptionsConstants.Empty }.Concat(_numbersProvider.Tens).ToList()));
            _positionalAndCalculatorDictionary.Add(new RomanPositionalExtractor(_numbersProvider.Hundreds, RomanExceptionsConstants.HundredsRemove, RomanExceptionsConstants.HundredsExists),
                                                   new StringBasedCalculator(new[] { RomanExceptionsConstants.Empty }.Concat(_numbersProvider.Hundreds).ToList()));
            _positionalAndCalculatorDictionary.Add(new RomanPositionalExtractor(_numbersProvider.Thousands, RomanExceptionsConstants.ThousandsRemove, RomanExceptionsConstants.Empty),
                                                   new StringBasedCalculator(new[] { RomanExceptionsConstants.Empty }.Concat(_numbersProvider.Thousands).ToList()));
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
                throw new OverflowException(MessageConstants.ResultTooBig);
            }
            return additionResult;
        }
    }
}
