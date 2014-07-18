using Microsoft.Practices.Prism.Commands;
using RomanNumbersCalculator.BL.Calculator;
using System;

namespace RomanNumbersCalculator.ViewModel
{
    public class CalculatorViewModel : ViewModelBase
    {
        private string _firstNumber;
        private string _secondNumber;
        private string _result;
        private EditNumber _editNumber;
        private RomanNumberCalculator _romanNumberCalculator;

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

        public DelegateCommand CalculateCommand { get; set; }
        public DelegateCommand FocusFirstNumberCommand { get; set; }
        public DelegateCommand FocusSecondNumberCommand { get; set; }
        public DelegateCommand<string> SendInputCommand { get; set; }

        public CalculatorViewModel()
        {
            _romanNumberCalculator = new RomanNumberCalculator();
            CalculateCommand = new DelegateCommand(OnCalculateExecute);
            FocusFirstNumberCommand = new DelegateCommand(OnFocusFirstNumberExecute);
            FocusSecondNumberCommand = new DelegateCommand(OnFocusSecondNumberExecute);
            SendInputCommand = new DelegateCommand<string>(OnSendInputExecute);
        }

        private void OnCalculateExecute()
        {
            Result = _romanNumberCalculator.Add(FirstNumber, SecondNumber);
        }

        private void OnSendInputExecute(string value)
        {
            switch (_editNumber)
            {
                case EditNumber.First:
                    FirstNumber = value + FirstNumber;
                    break;
                case EditNumber.Second:
                    SecondNumber = value + SecondNumber;
                    break;
            }
        }

        private void OnFocusFirstNumberExecute()
        {
            _editNumber = EditNumber.First;
        }

        private void OnFocusSecondNumberExecute()
        {
            _editNumber = EditNumber.Second;
        }

        private enum EditNumber
        {
            First, Second
        }
    }
}
