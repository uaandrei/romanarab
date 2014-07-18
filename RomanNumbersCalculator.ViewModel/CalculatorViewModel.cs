using Microsoft.Practices.Prism.Commands;
using RomanNumbersCalculator.BL.Calculator;
using RomanNumbersCalculator.BL.Model;
using System;

namespace RomanNumbersCalculator.ViewModel
{
    public class CalculatorViewModel : NotifiableObject
    {
        private EditNumber _editNumber;
        private RomanNumberCalculator _romanNumberCalculator;

        public RomanNumber FirstNumber
        {
            get;
            set;
        }

        public RomanNumber SecondNumber
        {
            get;
            set;
        }

        public RomanNumber Result
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

        public CalculatorViewModel()
        {
            FirstNumber = new RomanNumber();
            SecondNumber = new RomanNumber();
            Result = new RomanNumber();
            _romanNumberCalculator = new RomanNumberCalculator();
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
            Result.Value = _romanNumberCalculator.Add(FirstNumber.Value, SecondNumber.Value);
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
