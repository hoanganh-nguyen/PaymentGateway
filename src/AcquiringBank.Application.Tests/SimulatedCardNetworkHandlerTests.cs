using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcquiringBank.Domain.Interfaces;
using AcquiringBank.Domain.Models;
using FluentAssertions;
using PaymentGateway.Models;
using PaymentGateway.TestingSupport.ExampleGenerator;

namespace AcquiringBank.Application.Tests
{
    public class SimulatedCardNetworkHandlerTests
    {
        private readonly ICardNetworkHandler _cardNetworkHandler = new SimulatedCardNetworkHandler();

        [Fact]
        public void Should_accept_amount_under_100_for_Visa()
        {
            //Arrange
            var request = PaymentRequestGenerator.ValidPaymentRequest("4169773331987017", 75);
            //Act
            var ret = _cardNetworkHandler.ForwardToProcessAsync(CardType.Visa, request).Result;
            //Assert
            ret.Status.Should().BeTrue();

        }

        [Fact]
        public void Should_refuse_amount_over_200_for_MasterCard()
        {
            //Arrange
            var request = PaymentRequestGenerator.ValidPaymentRequest("5410710000901089", 250);
            //Act
            var ret = _cardNetworkHandler.ForwardToProcessAsync(CardType.MasterCard, request).Result;
            //Assert
            ret.Status.Should().BeFalse();

        }
    }
}
