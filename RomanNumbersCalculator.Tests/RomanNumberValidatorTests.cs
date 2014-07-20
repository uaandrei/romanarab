using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersCalculator.BL.RomanNumberSpecification;

namespace CalculatorModule.Tests
{
    [TestClass]
    public class RomanNumberValidatorTests
    {
        private RomanNumberValidator _validator;

        [TestInitialize]
        public void TestInitialize()
        {
            _validator = new RomanNumberValidator();
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsTrueForMMMDCXLVII()
        {
            Assert.IsTrue(_validator.IsSatisfiedBy("MMMDCXLVII"));
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsFalseForMMMDCXXLVII()
        {
            Assert.IsFalse(_validator.IsSatisfiedBy("MMMDCXXLVII"));
        }
    }
}
