using AcquiringBank.Domain.Validator;
using FluentAssertions;
using PaymentGateway.Application.Validator;

namespace PaymentGateway.Application.Tests.Validator
{
    public class CvvValidatorTests
    {
        private readonly ICvvValidator _cvvValidator;

        public CvvValidatorTests()
        {
            _cvvValidator = new RegexCvvValidator();
        }
        [Theory]
        [InlineData("561", true)]
        [InlineData("50614", false)]
        [InlineData("45a", false)]
        [InlineData("$51", false)]
        public void Should_return_true_when_cvv_has_3_or_4_number(string cvv, bool expected)
        {
            _cvvValidator.IsValid(cvv).Should().Be(expected);
        }
    }
}
