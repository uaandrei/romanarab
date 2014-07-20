using Infrastructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;
using RomanCalculatorModule.UserControls;
using RomanNumbersCalculator.BL;
using RomanNumbersCalculator.BL.Calculator;
using RomanNumbersCalculator.BL.Model;
using RomanNumbersCalculator.BL.NumberExceptions;
using RomanNumbersCalculator.BL.NumberValidator;
using RomanNumbersCalculator.BL.RomanNumberSpecification;
using System;
using System.Windows.Controls;

namespace RomanNumbersCalculator.ViewModel
{
    public class CalculatorViewModel : NotifiableObject, ICalculatorViewModel
    {
        private INumberCalculator _numberCalculator;
        private UserControl _userControl;
        private ISpecification<string> _numberValidator;

        private EditNumber _editNumber;

        public Number FirstNumber { get; set; }
        public Number SecondNumber { get; set; }
        public Number Result { get; set; }

        public UserControl InputControl
        {
            get { return _userControl; }
            set
            {
                _userControl = value;
                NotifyPropertyChanged("InputControl");
            }
        }

        public DelegateCommand CalculateCommand { get; set; }
        public DelegateCommand FocusFirstNumberCommand { get; set; }
        public DelegateCommand ClearFirstNumberCommand { get; set; }
        public DelegateCommand FocusSecondNumberCommand { get; set; }
        public DelegateCommand ClearSecondNumberCommand { get; set; }
        public DelegateCommand SwitchToRomanCommand { get; set; }
        public DelegateCommand SwitchToArabCommand { get; set; }
        public DelegateCommand<string> SendInputCommand { get; set; }

        public CalculatorViewModel()
        {
            CalculateCommand = new DelegateCommand(OnCalculateExecute, CanExecuteCalculate);
            FocusFirstNumberCommand = new DelegateCommand(OnFocusFirstNumberExecute);
            ClearFirstNumberCommand = new DelegateCommand(OnClearFirstNumberExecute);
            FocusSecondNumberCommand = new DelegateCommand(OnFocusSecondNumberExecute);
            ClearSecondNumberCommand = new DelegateCommand(OnClearSecondNumberExecute);
            SwitchToArabCommand = new DelegateCommand(OnSwitchToArabExecute);
            SwitchToRomanCommand = new DelegateCommand(OnSwitchToRomanExecute);
            SendInputCommand = new DelegateCommand<string>(OnSendInputExecute);
            FirstNumber = new Number();
            SecondNumber = new Number();
            Result = new Number();
            SetupRomanCalculator();
        }

        private void OnSwitchToRomanExecute()
        {
            SetupRomanCalculator();
        }

        private void OnSwitchToArabExecute()
        {
            SetupArabCalculator();
        }

        private void OnClearFirstNumberExecute()
        {
            FirstNumber.Value = string.Empty;
            Result.Value = string.Empty;
        }

        private void OnClearSecondNumberExecute()
        {
            SecondNumber.Value = string.Empty;
            Result.Value = string.Empty;
        }

        private bool CanExecuteCalculate()
        {
            return string.IsNullOrEmpty(FirstNumber.Error) && string.IsNullOrEmpty(SecondNumber.Error);
        }

        private void OnCalculateExecute()
        {
            try
            {
                Result.Value = _numberCalculator.Add(FirstNumber.Value, SecondNumber.Value);
            }
            catch (InvalidNumberException e)
            {
                Result.Value = e.Message;
            }
            catch (OverflowException e)
            {
                Result.Value = e.Message;
            }
        }

        private void OnSendInputExecute(string value)
        {
            switch (_editNumber)
            {
                case EditNumber.First:
                    FirstNumber.Value += value;
                    break;
                case EditNumber.Second:
                    SecondNumber.Value += value;
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

        private void SetupArabCalculator()
        {
            FirstNumber.Value = string.Empty;
            SecondNumber.Value = string.Empty;
            Result.Value = string.Empty;
            InputControl = new ArabNumbersControl();
            _numberCalculator = new ArabNumberCalculator();
            _numberValidator = new ArabNumberValidator();
            FirstNumber.SetSpecification(_numberValidator);
            SecondNumber.SetSpecification(_numberValidator);
        }

        private void SetupRomanCalculator()
        {
            FirstNumber.Value = string.Empty;
            SecondNumber.Value = string.Empty;
            Result.Value = string.Empty;
            InputControl = new RomanNumbersControl();
            _numberCalculator = new RomanNumberCalculator();
            _numberValidator = new RomanNumberValidator();
            FirstNumber.SetSpecification(_numberValidator);
            SecondNumber.SetSpecification(_numberValidator);
        }

        private enum EditNumber
        {
            First, Second
        }
    }
}
