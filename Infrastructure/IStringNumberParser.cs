using System.Collections.Generic;

namespace RomanNumbersCalculator.BL.StringNumberParser
{
    public interface IStringNumberParser
    {
        List<string> Parse(string stringvalue);
    }
}
