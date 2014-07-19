using RomanNumbersCalculator.BL.NumberProvider;
using RomanNumbersCalculator.BL.NumberExceptions;
using RomanNumbersCalculator.BL.RomanNumberSpecification;
using RomanNumbersCalculator.BL.StringNumberParser;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using Infrastructure;

namespace RomanNumbersCalculator.BL.Calculator
{
    public class NumberCalculator : INumberCalculator
    {
        private PositionalIdentifier _identifier;
        private StringBasedCalculator _unitsCalculator;
        private StringBasedCalculator _tensCalculator;
        private StringBasedCalculator _hundredsCalculator;
        private StringBasedCalculator _thousandsCalculator;
        private INumberProvider _numbersProvider;
        private ISpecification<string> _specification;
        private IStringNumberParser _parser;

        public NumberCalculator(IUnityContainer unityContainer)
        {
            _numbersProvider = unityContainer.Resolve<INumberProvider>();
            _specification = unityContainer.Resolve<ISpecification<string>>();
            _parser = unityContainer.Resolve<IStringNumberParser>();
            _identifier = new PositionalIdentifier(_numbersProvider);
            var symbols = new List<string>() { _numbersProvider.ZeroValue };
            symbols.AddRange(_numbersProvider.Units);
            _unitsCalculator = new StringBasedCalculator(symbols);

            symbols = new List<string>() { _numbersProvider.ZeroValue };
            symbols.AddRange(_numbersProvider.Tens);
            _tensCalculator = new StringBasedCalculator(symbols);

            symbols = new List<string>() { _numbersProvider.ZeroValue };
            symbols.AddRange(_numbersProvider.Hundreds);
            _hundredsCalculator = new StringBasedCalculator(symbols);

            symbols = new List<string>() { _numbersProvider.ZeroValue };
            symbols.AddRange(_numbersProvider.Thousands);
            _thousandsCalculator = new StringBasedCalculator(symbols);
        }

        public string Add(string number1, string number2)
        {
            if (!_specification.IsSatisfiedBy(number1))
            {
                throw new InvalidNumberException("First number is invalid.");
            }
            if (!_specification.IsSatisfiedBy(number2))
            {
                throw new InvalidNumberException("Second number is invalid.");
            }

            var positionalNumbersForFirstNumber = _parser.Parse(number1);
            var positionalNumbersForSecondNumber = _parser.Parse(number2);
            var additionResult = string.Empty;
            bool hasTransport = false;

            var value1 = positionalNumbersForFirstNumber.FirstOrDefault(p => _identifier.IsFromUnits(p)) ?? _numbersProvider.ZeroValue;
            var value2 = positionalNumbersForSecondNumber.FirstOrDefault(p => _identifier.IsFromUnits(p)) ?? _numbersProvider.ZeroValue;
            var unitsResult = _unitsCalculator.Add(value1, value2, ref hasTransport);
            additionResult = unitsResult;

            value1 = positionalNumbersForFirstNumber.FirstOrDefault(p => _identifier.IsFromTens(p)) ?? _numbersProvider.ZeroValue;
            value2 = positionalNumbersForSecondNumber.FirstOrDefault(p => _identifier.IsFromTens(p)) ?? _numbersProvider.ZeroValue;
            var tensResult = _tensCalculator.Add(value1, value2, ref hasTransport);
            additionResult = tensResult + additionResult;

            value1 = positionalNumbersForFirstNumber.FirstOrDefault(p => _identifier.IsFromHundreds(p)) ?? _numbersProvider.ZeroValue;
            value2 = positionalNumbersForSecondNumber.FirstOrDefault(p => _identifier.IsFromHundreds(p)) ?? _numbersProvider.ZeroValue;
            var hundredsResult = _hundredsCalculator.Add(value1, value2, ref hasTransport);
            additionResult = hundredsResult + additionResult;

            value1 = positionalNumbersForFirstNumber.FirstOrDefault(p => _identifier.IsFromThousands(p)) ?? _numbersProvider.ZeroValue;
            value2 = positionalNumbersForSecondNumber.FirstOrDefault(p => _identifier.IsFromThousands(p)) ?? _numbersProvider.ZeroValue;
            var thousandsResult = _thousandsCalculator.Add(value1, value2, ref hasTransport);
            if (hasTransport)
            {
                throw new OverflowException("Result is too big");
            }
            additionResult = thousandsResult + additionResult;

            return additionResult;
        }
    }
}
