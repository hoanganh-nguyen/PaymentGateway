using FluentAssertions;
using PaymentGateway.Application.Validator;
using PaymentGateway.Domain.Validator;

namespace PaymentGateway.Application.Tests.Validator
{
    public  class CardNumberValidatorTests
    {
        private readonly ICardNumberValidator _validator;

        public CardNumberValidatorTests()
        {
            _validator = new DefaultCardNumberValidator();
        }

        [Theory]
        [InlineData("5277 0291 2077 3860")]
        [InlineData("4556-0690-9685-2293")]
        [InlineData("4852789106979220268")]
        public void Should_return_true_for_valid_number(string cardNumber)
        {
            //Act & Assert
            _validator.IsValid(cardNumber).Should().BeTrue();
        }


        [Theory]
        [InlineData("4852 7891 0697 922 0261")]
        [InlineData("3543-6933-8731-4139")]
        [InlineData("6759310784561226")]
        public void Should_return_true_for_invalid_number(string cardNumber)
        {
            //Act & Assert
            _validator.IsValid(cardNumber).Should().BeFalse();
        }
    }
}
