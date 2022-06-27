using System.ComponentModel;
using FluentAssertions;
using PaymentGateway.Domain.Repository;
using PaymentGateway.Models;
using PaymentGateway.TestingSupport.ExampleGenerator;

namespace PaymentGateway.Infrastructure.Tests
{
    [Category("IntegrationTest")]
    public class PaymentInfoRepositoryTests
    {
        private readonly IPaymentInfoRepository _repository;

        public PaymentInfoRepositoryTests()
        {
            _repository = new FilePaymentInfoRepository();
        }

        [Fact]
        public void Should_able_save_and_get_payment_info()
        {
            //Arrange
            var paymentRequest = PaymentRequestGenerator.ValidPaymentRequest();
            var paymentId = Guid.NewGuid();
            var paymentInfo = new PaymentInfo()
            {
                Id = paymentId,
                Status = false,
                Amount = paymentRequest.Amount,
                Card = paymentRequest.CardInfo,
                LastUpdate = DateTime.Today
            };
            //Act
            var write = _repository.AddAsync(paymentInfo).Result;

            //Assert
            write.Should().BeTrue();

            var read = _repository.GetAsync(paymentInfo.Id).Result;
            read.Id.Should().Be(paymentId);
            read.Card.ExpiryMonth.Should().Be(paymentRequest.CardInfo.ExpiryMonth);
            read.Card.ExpiryYear.Should().Be(paymentRequest.CardInfo.ExpiryYear);
            read.Card.CardNumber.Should().Contain("*");

        }
    }
}