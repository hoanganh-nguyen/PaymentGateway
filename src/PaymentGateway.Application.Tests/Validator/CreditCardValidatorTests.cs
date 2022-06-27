using AcquiringBank.Domain.Validator;
using FluentAssertions;
using NSubstitute;
using PaymentGateway.Application.Validator;
using PaymentGateway.Domain.Validator;
using PaymentGateway.Models;

namespace PaymentGateway.Application.Tests.Validator
{
    public class CreditCardValidatorTests
    {
        private readonly ICreditCardValidator _validator;
        private readonly DateTime _now;
        private const string ValidCcNumber = "5555555555554444";
        private const string InvalidCcNumber = "5555555555554444x";
        private const string ValidCvv = "475";
        private const string InvalidCvv = "475x";

        public CreditCardValidatorTests()
        {
            _now = DateTime.Now;
            var cardNumberValidator = Substitute.For<ICardNumberValidator>();
            var cvvValidator = Substitute.For<ICvvValidator>();
            cardNumberValidator.IsValid(InvalidCcNumber).Returns(false);
            cardNumberValidator.IsValid(ValidCcNumber).Returns(true);
            cvvValidator.IsValid(InvalidCvv).Returns(false);
            cvvValidator.IsValid(ValidCvv).Returns(true);
            _validator = new CreditCardValidator(cardNumberValidator, cvvValidator);
        }
        [Fact]
        public void CreditCard_should_be_invalid_if_its_expired()
        {
            //Arrange
            var card = new CreditCard(ValidCcNumber, ValidCvv, _now.Month - 1, _now.Year);
            //Act
            var ret = _validator.IsValid(card);
            //Assert
            ret.Should().BeFalse();
        }

        [Fact]
        public void CreditCard_should_be_invalid_if_card_number_is_invalid()
        {
            //Arrange
            var card = new CreditCard(InvalidCcNumber, ValidCvv, _now.Month, _now.Year + 1);
            //Act
            var ret = _validator.IsValid(card);
            //Assert
            ret.Should().BeFalse();
        }


        [Fact]
        public void CreditCard_should_be_invalid_if_cvv_is_invalid()
        {
            //Arrange
            var card = new CreditCard(ValidCcNumber, InvalidCvv, _now.Month, _now.Year + 1);
            //Act
            var ret = _validator.IsValid(card);
            //Assert
            ret.Should().BeFalse();
        }


        [Fact]
        public void CreditCard_should_be_valid_if_card_number_cvv_expiry_are_all_valid()
        {
            //Arrange
            var card = new CreditCard(ValidCcNumber, ValidCvv, _now.Month, _now.Year + 1);
            //Act
            var ret = _validator.IsValid(card);
            //Assert
            ret.Should().BeTrue();
        }
    }
}