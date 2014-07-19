using RomanNumbersCalculator.BL;
using System.Windows.Data;

namespace RomanCalculatorModule.Converters
{
    public class RomanNumberValueConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string number = value as string;
            int test;
            if (number != null)
            {
                if (int.TryParse(number, out test))
                {
                    value = RomanNumberConverter.ToRoman(number);
                }
            }
            return value;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string number = value as string;
            int test;
            if (number != null)
            {
                if (!int.TryParse(number, out test))
                {
                    value = RomanNumberConverter.ToArab(number);
                }
            }
            return value;
        }
    }
}
