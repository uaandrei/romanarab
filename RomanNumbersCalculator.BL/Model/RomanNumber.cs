using RomanNumbersCalculator.BL.RomanNumberSpecification;
using System;
using System.ComponentModel;

namespace RomanNumbersCalculator.BL.Model
{
    public class RomanNumber : NotifiableObject, IDataErrorInfo
    {
        private string _value;
        private string _errorString;
        private RomanNumberValidator _validator;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                NotifyPropertyChanged("Value");
            }
        }

        public RomanNumber()
        {
            _value = string.Empty;
            _validator = new RomanNumberValidator(new ConsecutiveRomanPositionalsMustBeDescendingAndUnique());
        }

        public string Error
        {
            get { return _errorString; }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Value":
                        _errorString = _validator.IsValid(_value) ? string.Empty : "Invalid roman number";
                        break;
                }
                return _errorString;
            }
        }
    }
}
