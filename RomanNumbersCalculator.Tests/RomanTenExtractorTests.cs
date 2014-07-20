using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersCalculator.BL.PositionalExtractor;
using System.Collections.Generic;

namespace CalculatorModule.Tests
{
    [TestClass]
    public class RomanTenExtractorTests
    {
        private RomanPositionalExtractor _romanTenExtractor;

        [TestInitialize]
        public void TestInitialize()
        {
            var tens = new List<string> { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            _romanTenExtractor = new RomanPositionalExtractor(tens, "IX", "XL");
        }

        [TestMethod]
        public void Extract_ReturnsEmptyString()
        {
            var actual = _romanTenExtractor.Extract("MMIX");
            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void Extract_ReturnsXL()
        {
            var actual = _romanTenExtractor.Extract("MMXLV");
            Assert.AreEqual("XL", actual);
        }

        [TestMethod]
        public void Extract_ReturnsX()
        {
            var actual = _romanTenExtractor.Extract("MMXVI");
            Assert.AreEqual("X", actual);
        }
    }
}
