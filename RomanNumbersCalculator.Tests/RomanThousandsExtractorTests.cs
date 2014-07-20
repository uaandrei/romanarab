using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL.PositionalExtractor;
using System.Collections.Generic;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanThousandsExtractorTests
    {
        private RomanPositionalExtractor _romanThousandsExtractor;

        [TestInitialize]
        public void TestInitialize()
        {
            var hundreds = new List<string> { "M", "MM", "MMM" };
            _romanThousandsExtractor = new RomanPositionalExtractor(hundreds, "CM", string.Empty);
        }

        [TestMethod]
        public void Extract_ReturnsEmptyString()
        {
            var actual = _romanThousandsExtractor.Extract("CMVII");
            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void Extract_ReturnsMMM()
        {
            var actual = _romanThousandsExtractor.Extract("MMMCMVII");
            Assert.AreEqual("MMM", actual);
        }
    }
}
