using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersCalculator.BL.PositionalExtractor;

namespace CalculatorModule.Tests
{
    [TestClass]
    public class ArabUnitExtractorTests
    {
        private ArabPositionalExtractor _extractor;

        [TestInitialize]
        public void TestInitialize()
        {
            _extractor = new ArabPositionalExtractor(0);
        }

        [TestMethod]
        public void Extract_Returns0()
        {
            var actual = _extractor.Extract("880");
            Assert.AreEqual("0", actual);
        }

        [TestMethod]
        public void Extract_Returns7()
        {
            var actual = _extractor.Extract("887");
            Assert.AreEqual("7", actual);
        }

        [TestMethod]
        public void Extract_Returns0_When_EmptyString()
        {
            var actual = _extractor.Extract("");
            Assert.AreEqual("0", actual);
        }
    }
}
