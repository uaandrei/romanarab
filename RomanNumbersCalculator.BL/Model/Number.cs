using RomanNumbersCalculator.BL.RomanNumberSpecification;
using System;
using System.ComponentModel;

namespace RomanNumbersCalculator.BL.Model
{
    public class Number : NotifiableObject, IDataErrorInfo
    {
        private string _value;
        private string _errorString;
        private ISpecification<string> _specification;

        public string Error { get { return _errorString; } }

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                NotifyPropertyChanged("Value");
            }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Value":
                        _errorString = _specification.IsSatisfiedBy(_value) ? string.Empty : "Invalid roman number";
                        break;
                }
                return _errorString;
            }
        }

        public Number()
        {
            _value = string.Empty;
            _specification = new ConsecutiveRomanPositionalsMustBeDescendingAndUnique();
        }
    }
}
