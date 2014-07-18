using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;
using System.Collections.Generic;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanStringParserTests
    {
        [TestMethod]
        public void Parse_Should_ReturnAllRomanUnitsFromString_When_RomanSymbolsForUnitsArePassed()
        {
            var romanString = "XIXXIXVIIIMCMIVIXVIIXIIIM";

            var actualRomanUnits = new RomanStringParser(new RomanSymbolsGroup("I", "V", "X")).Parse(romanString);

            var expectedRomanUnits = new List<string> { "IX", "IX", "VIII", "IV", "IX", "VII", "III" };

            for (int i = 0; i < actualRomanUnits.Count; i++)
            {
                expectedRomanUnits.Remove(actualRomanUnits[i]);
            }

            Assert.IsTrue(expectedRomanUnits.Count == 0, string.Format("Failed to parse {0} roman units", expectedRomanUnits.Count));
        }

        [TestMethod]
        public void Parse_Should_ReturnAllRomanTensFromString_When_RomanSymbolsForTensArePassed()
        {
            var romanString = "MMXXXXIXLXXCCLVXCII";

            var actualRomanTens = new RomanStringParser(new RomanSymbolsGroup("X", "L", "C")).Parse(romanString);

            var expectedRomanTens = new List<string> { "XXX", "X", "XL", "XX", "L", "XC" };

            for (int i = 0; i < actualRomanTens.Count; i++)
            {
                expectedRomanTens.Remove(actualRomanTens[i]);
            }

            Assert.IsTrue(expectedRomanTens.Count == 0, string.Format("Failed to parse {0} roman tens", expectedRomanTens.Count));
        }

        [TestMethod]
        public void Parse_Should_ReturnAllRomanHundredsFromString_When_RomanSymbolsForThousandsArePassed()
        {
            var romanString = "CDCCCDIICMCXCX";

            var actualRomanHundreds = new RomanStringParser(new RomanSymbolsGroup("C", "D", "M")).Parse(romanString);

            var expectedRomanHundreds = new List<string> { "CD", "CCC", "D", "CM", "C", "C" };

            for (int i = 0; i < actualRomanHundreds.Count; i++)
            {
                expectedRomanHundreds.Remove(actualRomanHundreds[i]);
            }

            Assert.IsTrue(expectedRomanHundreds.Count == 0, string.Format("Failed to parse {0} roman hundred", expectedRomanHundreds.Count));
        }

        [TestMethod]
        public void Parse_Should_ReturnAllRomanThousandsFromString_When_RomanHundredsNumbersArePassed()
        {
            var romanString = "MMCMMMMIXCM";

            var actualRomanThousands = new RomanStringParser(RomanNumbersGenerator.GenerateRomanThousands()).Parse(romanString);

            var expectedRomanThousands = new List<string> { "MM", "MMM", "M", "M" };

            for (int i = 0; i < actualRomanThousands.Count; i++)
            {
                expectedRomanThousands.Remove(actualRomanThousands[i]);
            }

            Assert.IsTrue(expectedRomanThousands.Count == 0, string.Format("Failed to parse {0} roman thousands", expectedRomanThousands.Count));
        }
    }
}
