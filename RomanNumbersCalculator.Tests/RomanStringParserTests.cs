using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL.StringNumberParser;
using System.Collections.Generic;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanStringParserTests
    {
        [TestMethod]
        public void Parse_ReturnsAllRomanNumbersFromString()
        {
            var romanString = "XIXMCMMIIIVIIIXCMMIIVLXDLDXDM";

            var actualRomanUnits = new RomanStringParser().Parse(romanString);

            var expectedRomanUnits = new List<string> { "X", "IX", "M", "CM", "M", "III", "VIII", "XC", "MM", "II", "V", "LX", "D", "L", "D", "X", "D", "M" };

            for (int i = 0; i < actualRomanUnits.Count; i++)
            {
                expectedRomanUnits.Remove(actualRomanUnits[i]);
            }

            Assert.IsTrue(expectedRomanUnits.Count == 0, string.Format("Failed to parse {0} roman units", expectedRomanUnits.Count));
        }
    }
}
