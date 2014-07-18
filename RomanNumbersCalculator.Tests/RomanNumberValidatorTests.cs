using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersCalculator.BL;
using RomanNumbersCalculator.BL.RomanNumberSpecification;
using Moq;

namespace RomanNumbersCalculator.Tests
{
    [TestClass]
    public class RomanNumberValidatorTests
    {
        private RomanNumberValidator _romanNumberValidator;

        [TestMethod]
        public void Validate_ReturnsTrue_When_SpecificationIsTrue()
        {
            var mockedSpecification = new Mock<ISpecification<string>>();
            mockedSpecification.Setup(p => p.IsSatisfiedBy(It.IsAny<string>())).Returns(true);

            _romanNumberValidator = new RomanNumberValidator(mockedSpecification.Object);

            Assert.IsTrue(_romanNumberValidator.IsValid(string.Empty));
        }
    }
}
