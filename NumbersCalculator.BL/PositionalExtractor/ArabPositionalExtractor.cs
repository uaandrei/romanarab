using Infrastructure;
using NumbersCalculator.BL.NumberProvider;

namespace NumbersCalculator.BL.PositionalExtractor
{
    public class ArabPositionalExtractor : IPositionalExtractor
    {
        private readonly int _position;

        public ArabPositionalExtractor(int position)
        {
            _position = position;
        }

        public string Extract(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return ArabNumbersProvider.Zero;
            }
            if (_position >= value.Length)
            {
                return ArabNumbersProvider.Zero;
            }
            return value[value.Length - 1 - _position].ToString();
        }
    }
}
