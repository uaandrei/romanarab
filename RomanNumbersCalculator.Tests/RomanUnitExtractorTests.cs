using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL.PositionalExtractor;
using RomanNumbersCalculator.BL.NumberExceptions;
using Moq;
using RomanNumbersCalculator.BL.NumberProvider;
using System.Collections.Generic;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanUnitExtractorTests
    {
        private RomanPositionalExtractor _romanUnitExtractor;

        [TestInitialize]
        public void TestInitialize()
        {
            var units = new List<string> { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            _romanUnitExtractor = new RomanPositionalExtractor(units, string.Empty, "IV");
        }

        [TestMethod]
        public void Extract_ReturnsIX()
        {
            var actual = _romanUnitExtractor.Extract("MCDLIX");
            Assert.AreEqual("IX", actual);
        }

        [TestMethod]
        public void Extract_ReturnsIV()
        {
            var actual = _romanUnitExtractor.Extract("MCDLIV");
            Assert.AreEqual("IV", actual);
        }

        [TestMethod]
        public void Extract_ReturnsVIII()
        {
            var actual = _romanUnitExtractor.Extract("MCDLVIII");
            Assert.AreEqual("VIII", actual);
        }

        [TestMethod]
        public void Extract_ReturnsIII()
        {
            var actual = _romanUnitExtractor.Extract("MCDLIII");
            Assert.AreEqual("III", actual);
        }

        [TestMethod]
        public void Extract_ReturnsEmptyString()
        {
            var actual = _romanUnitExtractor.Extract("MCDLXXX");
            Assert.AreEqual(string.Empty, actual);
        }
    }
}
