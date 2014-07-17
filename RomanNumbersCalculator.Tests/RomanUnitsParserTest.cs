using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;
using System.Collections.Generic;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanUnitsParserTest
    {
        [TestMethod]
        public void Parse_Should_ReturnAllRomanUnits_When_StringContainsMixedRomanNumbers()
        {
            var romanString = "XIXXIXVIIIMCMIVIXVIIXIIIM";

            var actualRomanUnits = new RomanUnitsParser().Parse(romanString);

            var expectedRomanUnits = new List<string> { "IX", "IX", "VIII", "IV", "IX", "VII", "III" };

            for (int i = 0; i < actualRomanUnits.Count; i++)
            {
                expectedRomanUnits.Remove(actualRomanUnits[i]);
            }

            Assert.IsTrue(expectedRomanUnits.Count == 0, string.Format("Failed to parse {0} roman units", expectedRomanUnits.Count));
        }
    }
}
