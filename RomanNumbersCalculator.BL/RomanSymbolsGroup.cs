namespace RomanNumbersCalculator.BL
{
    public class RomanSymbolsGroup
    {
        public string FirstNumber { get; set; }
        public string MiddleNumber { get; set; }
        public string MaxNumber { get; set; }

        public static RomanSymbolsGroup UnitsGroup
        {
            get
            {
                return new RomanSymbolsGroup("I", "V", "X");
            }
        }

        public static RomanSymbolsGroup TensGroup
        {
            get
            {
                return new RomanSymbolsGroup("X", "L", "C");
            }
        }

        public static RomanSymbolsGroup HundredsGroup
        {
            get
            {
                return new RomanSymbolsGroup("C", "D", "M");
            }
        }

        public RomanSymbolsGroup(string firstNumber, string middleNumber, string maxNumber)
        {
            FirstNumber = firstNumber;
            MiddleNumber = middleNumber;
            MaxNumber = maxNumber;
        }
    }
}
