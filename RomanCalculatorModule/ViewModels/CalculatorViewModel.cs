using Infrastructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;
using RomanNumbersCalculator.BL.Calculator;
using RomanNumbersCalculator.BL.Model;
using RomanNumbersCalculator.BL.NumberExceptions;
using System;

namespace RomanNumbersCalculator.ViewModel
{
    public class CalculatorViewModel : NotifiableObject, ICalculatorViewModel
    {
        private EditNumber _editNumber;
        private INumberCalculator _numberCalculator;

        public Number FirstNumber
        {
            get;
            set;
        }

        public Number SecondNumber
        {
            get;
            set;
        }

        public Number Result
        {
            get;
            set;
        }

        public DelegateCommand CalculateCommand { get; set; }
        public DelegateCommand FocusFirstNumberCommand { get; set; }
        public DelegateCommand ClearFirstNumberCommand { get; set; }
        public DelegateCommand FocusSecondNumberCommand { get; set; }
        public DelegateCommand ClearSecondNumberCommand { get; set; }
        public DelegateCommand<string> SendInputCommand { get; set; }

        public CalculatorViewModel(IUnityContainer unityContainer)
        {
            FirstNumber = new Number(unityContainer);
            SecondNumber = new Number(unityContainer);
            Result = new Number(unityContainer);
            _numberCalculator = unityContainer.Resolve<INumberCalculator>();
            CalculateCommand = new DelegateCommand(OnCalculateExecute);
            FocusFirstNumberCommand = new DelegateCommand(OnFocusFirstNumberExecute);
            ClearFirstNumberCommand = new DelegateCommand(OnClearFirstNumberExecute);
            FocusSecondNumberCommand = new DelegateCommand(OnFocusSecondNumberExecute);
            ClearSecondNumberCommand = new DelegateCommand(OnClearSecondNumberExecute);
            SendInputCommand = new DelegateCommand<string>(OnSendInputExecute);
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

        private enum EditNumber
        {
            First, Second
        }
    }
}
