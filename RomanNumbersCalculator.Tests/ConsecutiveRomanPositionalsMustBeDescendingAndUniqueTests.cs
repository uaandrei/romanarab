using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL.RomanNumberSpecification;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class ConsecutiveRomanPositionalsMustBeDescendingAndUniqueTests
    {
        private ConsecutiveRomanPositionalsMustBeDescendingAndUnique _descendingPositionalsSpec;

        [TestInitialize]
        public void TestInitialize()
        {
            _descendingPositionalsSpec = new ConsecutiveRomanPositionalsMustBeDescendingAndUnique();
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsTrue_When_AllPositionalsArePresentAndAreDescending()
        {
            var candidate = "MMCMXXVII";

            Assert.IsTrue(_descendingPositionalsSpec.IsSatisfiedBy(candidate));
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsFalse_When_PositionalsAreNotDescending()
        {
            var candidate = "CMMCMXXVII";

            Assert.IsFalse(_descendingPositionalsSpec.IsSatisfiedBy(candidate));
        }
    }
}
