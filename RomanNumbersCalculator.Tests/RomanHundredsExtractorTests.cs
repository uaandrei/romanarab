using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL.PositionalExtractor;
using System.Collections.Generic;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanHundredsExtractorTests
    {
        private RomanPositionalExtractor _romanHundredsExtractor;

        [TestInitialize]
        public void TestInitialize()
        {
            var hundreds = new List<string> { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            _romanHundredsExtractor = new RomanPositionalExtractor(hundreds, "XC", "CD");
        }

        [TestMethod]
        public void Extract_ReturnsEmptyString()
        {
            var actual = _romanHundredsExtractor.Extract("MMXC");
            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void Extract_ReturnsCD()
        {
            var actual = _romanHundredsExtractor.Extract("MMCDV");
            Assert.AreEqual("CD", actual);
        }

        [TestMethod]
        public void Extract_ReturnsX()
        {
            var actual = _romanHundredsExtractor.Extract("MMCVI");
            Assert.AreEqual("C", actual);
        }
    }
}
