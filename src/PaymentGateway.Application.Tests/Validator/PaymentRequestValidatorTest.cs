using FluentAssertions;
using NSubstitute;
using PaymentGateway.Application.Validator;
using PaymentGateway.Domain.Validator;
using PaymentGateway.TestingSupport.ExampleGenerator;

namespace PaymentGateway.Application.Tests.Validator
{
    public class PaymentRequestValidatorTest
    {
        private readonly IPaymentRequestValidator _validator;
        private readonly ISupportedCurrencyValidator _currencyRepository;
        private readonly ICreditCardValidator _creditCardValidator;
        public PaymentRequestValidatorTest()
        {
            _creditCardValidator = Substitute.For<ICreditCardValidator>();
            _currencyRepository = Substitute.For<ISupportedCurrencyValidator>();
            _validator = new PaymentRequestValidator(_currencyRepository, _creditCardValidator);
        }

        [Fact]
        public void Should_return_false_when_amount_is_negative_or_empty()
        {
            //Arrange
            var paymentRequest = PaymentRequestGenerator.PaymentRequestWithNegativeAmount();
            //Act 
            var ret = _validator.IsValid(paymentRequest);
            //Assert
            ret.Should().BeFalse();

        }

        [Fact]
        public void Should_return_false_when_currency_is_unsupported()
        {
            //Arrange
            var paymentRequest = PaymentRequestGenerator.PaymentRequestWithUnknownCurrency();
            _currencyRepository.IsValid(paymentRequest.Amount.Currency).Returns(false);
            //Act 
            var ret = _validator.IsValid(paymentRequest);
            //Assert
            ret.Should().BeFalse();

        }

        [Fact]
        public void Should_return_false_when_credit_card_is_invalid()
        {
            //Arrange
            var paymentRequest = PaymentRequestGenerator.PaymentRequestWithInvalidCreditCard();
            _creditCardValidator.IsValid(paymentRequest.CardInfo).Returns(false);
            //Act 
            var ret = _validator.IsValid(paymentRequest);
            //Assert
            ret.Should().BeFalse();
        }

        [Fact]
        public void Should_return_true_when_all_criteria_are_valid()
        {
            //Arrange
            var paymentRequest = PaymentRequestGenerator.ValidPaymentRequest();
            _creditCardValidator.IsValid(paymentRequest.CardInfo).Returns(true);
            _currencyRepository.IsValid(paymentRequest.Amount!.Currency).Returns(true);
            //Act 
            var ret = _validator.IsValid(paymentRequest);
            //Assert
            ret.Should().BeTrue();
        }
    }
}
