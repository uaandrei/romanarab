using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RomanNumbersCalculator.BL.Specification;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class AndSpecificationTests
    {
        private AndSpecification<object> _andSpecification;

        [TestMethod]
        public void IsSatisfiedBy_ReturnsTrue_When_BothSpecificationsAreTrue()
        {
            var mockedAndSpecification1 = new Mock<ISpecification<object>>();
            mockedAndSpecification1.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);
            var mockedAndSpecification2 = new Mock<ISpecification<object>>();
            mockedAndSpecification2.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);

            _andSpecification = new AndSpecification<object>(mockedAndSpecification1.Object, mockedAndSpecification2.Object);

            Assert.IsTrue(_andSpecification.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsFalse_When_FirstSpecificationIsTrueAndSecondIsFalse()
        {
            var mockedAndSpecification1 = new Mock<ISpecification<object>>();
            mockedAndSpecification1.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);
            var mockedAndSpecification2 = new Mock<ISpecification<object>>();
            mockedAndSpecification2.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(false);

            _andSpecification = new AndSpecification<object>(mockedAndSpecification1.Object, mockedAndSpecification2.Object);

            Assert.IsFalse(_andSpecification.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsFalse_When_FirstSpecificationIsFalseAndSecondIsTrue()
        {
            var mockedAndSpecification1 = new Mock<ISpecification<object>>();
            mockedAndSpecification1.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(false);
            var mockedAndSpecification2 = new Mock<ISpecification<object>>();
            mockedAndSpecification2.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);

            _andSpecification = new AndSpecification<object>(mockedAndSpecification1.Object, mockedAndSpecification2.Object);

            Assert.IsFalse(_andSpecification.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void IsSatisfiedBy_ReturnsFalse_When_BothSpecificationsAreFalse()
        {
            var mockedAndSpecification1 = new Mock<ISpecification<object>>();
            mockedAndSpecification1.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(false);
            var mockedAndSpecification2 = new Mock<ISpecification<object>>();
            mockedAndSpecification2.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(false);

            _andSpecification = new AndSpecification<object>(mockedAndSpecification1.Object, mockedAndSpecification2.Object);

            Assert.IsFalse(_andSpecification.IsSatisfiedBy(new object()));
        }
    }
}
