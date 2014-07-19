using Infrastructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;
using RomanCalculatorModule.UserControls;
using RomanNumbersCalculator.BL.Calculator;
using RomanNumbersCalculator.BL.Model;
using RomanNumbersCalculator.BL.NumberExceptions;
using RomanNumbersCalculator.BL.NumberProvider;
using RomanNumbersCalculator.BL.RomanNumberSpecification;
using RomanNumbersCalculator.BL.StringNumberParser;
using System;
using System.Windows.Controls;

namespace RomanNumbersCalculator.ViewModel
{
    public class CalculatorViewModel : NotifiableObject, ICalculatorViewModel
    {
        private EditNumber _editNumber;
        private INumberCalculator _numberCalculator;
        private UserControl _userControl;

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

        public CalculatorViewModel(IUnityContainer container)
        {
            CalculateCommand = new DelegateCommand(OnCalculateExecute);
            FocusFirstNumberCommand = new DelegateCommand(OnFocusFirstNumberExecute);
            ClearFirstNumberCommand = new DelegateCommand(OnClearFirstNumberExecute);
            FocusSecondNumberCommand = new DelegateCommand(OnFocusSecondNumberExecute);
            ClearSecondNumberCommand = new DelegateCommand(OnClearSecondNumberExecute);
            SwitchToArabCommand = new DelegateCommand(OnSwitchToArabExecute);
            SwitchToRomanCommand = new DelegateCommand(OnSwitchToRomanExecute);
            SendInputCommand = new DelegateCommand<string>(OnSendInputExecute);
            InputControl = new RomanNumbersControl();
            FirstNumber = new Number();
            FirstNumber.SetSpecification(container.Resolve<ISpecification<string>>());
            SecondNumber = new Number();
            SecondNumber.SetSpecification(container.Resolve<ISpecification<string>>());
            Result = new Number();
            Result.SetSpecification(container.Resolve<ISpecification<string>>());
            _numberCalculator = new NumberCalculator(container);
        }

        private void OnSwitchToRomanExecute()
        {
            InputControl = new RomanNumbersControl();
        }

        private void OnSwitchToArabExecute()
        {
            InputControl = new ArabNumbersControl();
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

        private void InitializeCalculator(IUnityContainer unityContainer)
        {
            _numberCalculator = new NumberCalculator(unityContainer);
        }

        private enum EditNumber
        {
            First, Second
        }
    }
}
