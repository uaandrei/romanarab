using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;
using Moq;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class AndSpecificationTests
    {
        private AndSpecification<object> _andSpecification;

        [TestMethod]
        public void IsSatisfiedBy_Should_ReturnTrue_When_BothSpecificationsAreTrue()
        {
            var mockedAndSpecification1 = new Mock<ISpecification<object>>();
            mockedAndSpecification1.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);
            var mockedAndSpecification2 = new Mock<ISpecification<object>>();
            mockedAndSpecification2.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);

            _andSpecification = new AndSpecification<object>(mockedAndSpecification1.Object, mockedAndSpecification2.Object);

            Assert.IsTrue(_andSpecification.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void IsSatisfiedBy_Should_ReturnFalse_When_FirstSpecificationIsTrueAndSecondIsFalse()
        {
            var mockedAndSpecification1 = new Mock<ISpecification<object>>();
            mockedAndSpecification1.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);
            var mockedAndSpecification2 = new Mock<ISpecification<object>>();
            mockedAndSpecification2.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(false);

            _andSpecification = new AndSpecification<object>(mockedAndSpecification1.Object, mockedAndSpecification2.Object);

            Assert.IsFalse(_andSpecification.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void IsSatisfiedBy_Should_ReturnFalse_When_FirstSpecificationIsFalseAndSecondIsTrue()
        {
            var mockedAndSpecification1 = new Mock<ISpecification<object>>();
            mockedAndSpecification1.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(false);
            var mockedAndSpecification2 = new Mock<ISpecification<object>>();
            mockedAndSpecification2.Setup(p => p.IsSatisfiedBy(It.IsAny<object>())).Returns(true);

            _andSpecification = new AndSpecification<object>(mockedAndSpecification1.Object, mockedAndSpecification2.Object);

            Assert.IsFalse(_andSpecification.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void IsSatisfiedBy_Should_ReturnFalse_When_BothSpecificationsAreFalse()
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
