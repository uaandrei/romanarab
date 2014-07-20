using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL.PositionalExtractor;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class ArabTensExtractorTests
    {
        private ArabPositionalExtractor _extractor;

        [TestInitialize]
        public void TestInitialize()
        {
            _extractor = new ArabPositionalExtractor(1);
        }

        [TestMethod]
        public void Extract_Returns0_WhenPositionalIsNotPresent()
        {
            var actual = _extractor.Extract("1");
            Assert.AreEqual("0", actual);
        }

        [TestMethod]
        public void Extract_Returns3()
        {
            var actual = _extractor.Extract("136");
            Assert.AreEqual("3", actual);
        }
    }
}
