namespace RomanNumbersCalculator.BL
{
    public class RomanSymbolsGroup
    {
        public string FirstNumber { get; set; }
        public string MiddleNumber { get; set; }
        public string MaxNumber { get; set; }
        
        public RomanSymbolsGroup(string firstNumber, string middleNumber, string maxNumber)
        {
            FirstNumber = firstNumber;
            MiddleNumber = middleNumber;
            MaxNumber = maxNumber;
        }
    }
}
