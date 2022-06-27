using FluentAssertions;
using NSubstitute;
using PaymentGateway.Application.Processor;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Domain.Repository;
using PaymentGateway.Domain.Validator;
using PaymentGateway.Models;
using PaymentGateway.TestingSupport.ExampleGenerator;

namespace PaymentGateway.Application.Tests
{
    public class PaymentGatewayProcessorTests
    {
        private readonly IAcquiringBankHandler _acquiringBankHandler;
        private readonly IPaymentInfoRepository _repository;
        private readonly IPaymentGateway _paymentGateway;
        public PaymentGatewayProcessorTests()
        {
            _acquiringBankHandler = Substitute.For<IAcquiringBankHandler>();
            _repository = Substitute.For<IPaymentInfoRepository>();
            _paymentGateway = new PaymentProcessor(_acquiringBankHandler, _repository) ;
        }
        


        [Fact]
        public void Should_unable_to_process_payment_when_payment_request_valid_but_acquiring_bank_denies()
        {
            //Arrange
            var paymentRequest = PaymentRequestGenerator.ValidPaymentRequest();
            _acquiringBankHandler.ProcessAsync(paymentRequest)
                .Returns(x => Task.FromResult(new PaymentResponse(Guid.NewGuid(), false)));

            //Act
            var ret = _paymentGateway.ProcessPaymentAsync(paymentRequest).Result;

            //Assert
            ret.Should().NotBeNull();
            ret.Id.Should().NotBeEmpty();
            ret.Status.Should().BeFalse();

        }

        [Fact]
        public void Should_able_to_process_payment_when_payment_request_valid_and_acquiring_bank_accepts()
        {
            //Arrange
            var paymentRequest = PaymentRequestGenerator.ValidPaymentRequest();
            _acquiringBankHandler.ProcessAsync(paymentRequest)
                .Returns(x => Task.FromResult(new PaymentResponse(Guid.NewGuid(), true)));

            //Act
            var ret = _paymentGateway.ProcessPaymentAsync(paymentRequest).Result;

            //Assert
            ret.Should().NotBeNull();
            ret.Id.Should().NotBeEmpty();
            ret.Status.Should().BeTrue();

        }

        [Fact]
        public void Should_retrieve_payment_info_if_it_is_previously_made()
        {
            //Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).Returns(x => new PaymentInfo() { Id = id }); ;

            //Act
            var ret = _paymentGateway.RetrievePaymentDetailsAsync(id).Result;

            //Assert
            ret.Should().NotBeNull();
            ret.Id.Should().Be(id);

        }

        [Fact]
        public void Should_not_retrieve_payment_info_if_there_is_not_previously_made()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            var ret = _paymentGateway.RetrievePaymentDetailsAsync(id).Result;

            //Assert
            ret.Should().BeNull();

        }
    }
}