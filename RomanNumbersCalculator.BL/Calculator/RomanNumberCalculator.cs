using RomanNumbersCalculator.BL.NumberProvider;
using RomanNumbersCalculator.BL.RomanNumberExceptions;
using RomanNumbersCalculator.BL.RomanNumberSpecification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumbersCalculator.BL.Calculator
{
    public class RomanNumberCalculator
    {
        private RomanNumberValidator _numberValidator;
        private RomanStringParser _parser;
        private PositionalIdentifier _identifier;
        private StringBasedCalculator _unitsCalculator;
        private StringBasedCalculator _tensCalculator;
        private StringBasedCalculator _hundredsCalculator;
        private StringBasedCalculator _thousandsCalculator;
        private RomanNumbersProvider _romanNumbersContainer = new RomanNumbersProvider();

        public RomanNumberCalculator()
        {
            _numberValidator = new RomanNumberValidator(new ConsecutiveRomanPositionalsMustBeDescendingAndUnique());
            _parser = new RomanStringParser();
            _identifier = new PositionalIdentifier(new RomanNumbersProvider());
            var symbols = new List<string>() { null };
            symbols.AddRange(_romanNumbersContainer.Units);
            _unitsCalculator = new StringBasedCalculator(symbols);

            symbols = new List<string>() { null };
            symbols.AddRange(_romanNumbersContainer.Tens);
            _tensCalculator = new StringBasedCalculator(symbols);

            symbols = new List<string>() { null };
            symbols.AddRange(_romanNumbersContainer.Hundreds);
            _hundredsCalculator = new StringBasedCalculator(symbols);

            symbols = new List<string>() { null };
            symbols.AddRange(_romanNumbersContainer.Thousands);
            _thousandsCalculator = new StringBasedCalculator(symbols);
        }

        public string Add(string number1, string number2)
        {
            if (!_numberValidator.IsValid(number1))
            {
                throw new InvalidRomanNumberException("First number is invalid.");
            }
            if (!_numberValidator.IsValid(number2))
            {
                throw new InvalidRomanNumberException("Second number is invalid.");
            }

            var positionalNumbersForFirstNumber = _parser.Parse(number1);
            var positionalNumbersForSecondNumber = _parser.Parse(number2);
            var additionResult = string.Empty;
            bool hasTransport = false;

            var value1 = positionalNumbersForFirstNumber.FirstOrDefault(p => _identifier.IsFromUnits(p));
            var value2 = positionalNumbersForSecondNumber.FirstOrDefault(p => _identifier.IsFromUnits(p));
            var unitsResult = _unitsCalculator.Add(value1, value2, ref hasTransport);
            additionResult = unitsResult;

            value1 = positionalNumbersForFirstNumber.FirstOrDefault(p => _identifier.IsFromTens(p));
            value2 = positionalNumbersForSecondNumber.FirstOrDefault(p => _identifier.IsFromTens(p));
            var tensResult = _tensCalculator.Add(value1, value2, ref hasTransport);
            additionResult = tensResult + additionResult;

            value1 = positionalNumbersForFirstNumber.FirstOrDefault(p => _identifier.IsFromHundreds(p));
            value2 = positionalNumbersForSecondNumber.FirstOrDefault(p => _identifier.IsFromHundreds(p));
            var hundredsResult = _hundredsCalculator.Add(value1, value2, ref hasTransport);
            additionResult = hundredsResult + additionResult;

            value1 = positionalNumbersForFirstNumber.FirstOrDefault(p => _identifier.IsFromThousands(p));
            value2 = positionalNumbersForSecondNumber.FirstOrDefault(p => _identifier.IsFromThousands(p));
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
