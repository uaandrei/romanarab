namespace RomanNumbersCalculator.BL.Model
{
    public class RomanNumber : NotifiableObject
    {
        private string _value;

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
        }
    }
}
