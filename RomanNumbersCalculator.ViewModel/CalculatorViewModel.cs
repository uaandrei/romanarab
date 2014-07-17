﻿using Microsoft.Practices.Prism.Commands;
using RomanNumbersCalculator.BL;
using System;
using System.Windows.Input;

namespace RomanNumbersCalculator.ViewModel
{
    public class CalculatorViewModel : ViewModelBase
    {
        private string _firstNumber;
        private string _secondNumber;
        private string _result;
        private RomanArabicConverter _romanArabicConverter;

        public string FirstNumber
        {
            get
            {
                return _firstNumber;
            }
            set
            {
                if (_firstNumber != value)
                {
                    _firstNumber = value;
                    NotifyPropertyChanged("FirstNumber");
                    AddValuesCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string SecondNumber
        {
            get
            {
                return _secondNumber;
            }
            set
            {
                if (_secondNumber != value)
                {
                    _secondNumber = value;
                    NotifyPropertyChanged("SecondNumber");
                    AddValuesCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    NotifyPropertyChanged("Result");
                }
            }
        }

        public DelegateCommand AddValuesCommand { get; set; }

        public CalculatorViewModel()
        {
            _romanArabicConverter = new RomanArabicConverter();
            AddValuesCommand = new DelegateCommand(ExecuteAddValues, CanExecuteAddValues);
        }

        private bool CanExecuteAddValues()
        {
            return !string.IsNullOrWhiteSpace(FirstNumber) && !string.IsNullOrWhiteSpace(SecondNumber);
        }

        private void ExecuteAddValues()
        {
            var arab1 = Convert.ToInt32(FirstNumber);
            var arab2 = Convert.ToInt32(SecondNumber);

            Result = _romanArabicConverter.ToRoman(arab1 + arab2);
        }

    }
}