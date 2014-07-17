using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RomanNumbersCalculator.BL.Specification;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class XorSpecificationTests
    {
        private XorSpecification<object> _xorSpecification;

        [TestMethod]
        public void IsSatisfiedBy_Should_ReturnFalse_When_BothSpecificationsAreTrue()
        {
            var mockedXorSpecification1 = new Mock<ISpecification<object>>();
            mockedXorSpecification1.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);
            var mockedXorSpecification2 = new Mock<ISpecification<object>>();
            mockedXorSpecification2.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);

            _xorSpecification = new XorSpecification<object>(mockedXorSpecification1.Object, mockedXorSpecification2.Object);

            Assert.IsFalse(_xorSpecification.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void IsSatisfiedBy_Should_ReturnTrue_When_FirstSpecificationIsTrueAndSecondIsFalse()
        {
            var mockedXorSpecification1 = new Mock<ISpecification<object>>();
            mockedXorSpecification1.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);
            var mockedXorSpecification2 = new Mock<ISpecification<object>>();
            mockedXorSpecification2.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(false);

            _xorSpecification = new XorSpecification<object>(mockedXorSpecification1.Object, mockedXorSpecification2.Object);

            Assert.IsTrue(_xorSpecification.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void IsSatisfiedBy_Should_ReturnTrue_When_FirstSpecificationIsFalseAndSecondIsTrue()
        {
            var mockedXorSpecification1 = new Mock<ISpecification<object>>();
            mockedXorSpecification1.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(false);
            var mockedXorSpecification2 = new Mock<ISpecification<object>>();
            mockedXorSpecification2.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);

            _xorSpecification = new XorSpecification<object>(mockedXorSpecification1.Object, mockedXorSpecification2.Object);

            Assert.IsTrue(_xorSpecification.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void IsSatisfiedBy_Should_ReturnFalse_When_BothSpecificationsAreFalse()
        {
            var mockedXorSpecification1 = new Mock<ISpecification<object>>();
            mockedXorSpecification1.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(false);
            var mockedXorSpecification2 = new Mock<ISpecification<object>>();
            mockedXorSpecification2.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(false);

            _xorSpecification = new XorSpecification<object>(mockedXorSpecification1.Object, mockedXorSpecification2.Object);

            Assert.IsFalse(_xorSpecification.IsSatisfiedBy(new object()));
        }
    }
}
