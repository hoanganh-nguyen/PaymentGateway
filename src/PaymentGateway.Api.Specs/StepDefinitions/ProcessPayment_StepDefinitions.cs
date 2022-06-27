using PaymentGateway.Api.Specs.Support;
using PaymentGateway.Models;
using PaymentGateway.TestingSupport.ExampleGenerator;

namespace PaymentGateway.Api.Specs.StepDefinitions
{
    [Binding]
    public class ProcessPaymentStepDefinitions: PaymentBaseStepDefinitions
    {

        #region When

        [When(@"submitting a payment request")]
        public void WhenSubmittingAPaymentRequest()
        {
            var data = JsonData(Request);
            HttpResponseMessage = Task.Run(async () => await Client!.PostAsync(PaymentEndpoint, data)).Result;
        }
        #endregion

        #region Given
        [Given(@"Shopper provides a bad payment request")]
        public void GivenShopperProvidesABadPaymentRequest()
        {
            Request = PaymentRequestGenerator.PaymentRequestWithNegativeAmount();
        }

        [Given(@"Shopper provides an invalid credit card")]
        public void GivenShopperProvidesAnInvalidCreditCard()
        {
            Request = PaymentRequestGenerator.PaymentRequestWithInvalidCreditCard();
        }

        [Given(@"Shopper provides a valid payment request")]
        public void GivenShopperProvidesAValidPaymentRequest()
        {
            Request = PaymentRequestGenerator.ValidPaymentRequest();
        }

        #endregion Given

        #region Then
        [Then(@"the error code is unprocessable entity")]
        public void ThenTheErrorCodeIsUnprocessableEntity()
        {
            HttpResponseMessage.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Then(@"payment gateway returns a unsuccessful response")]
        public void ThenPaymentGatewayReturnsAUnsuccessfulResponse()
        {
            HttpResponseMessage.IsSuccessStatusCode.Should().BeFalse();
        }

        [Then(@"the error code is bad request")]
        public void ThenTheErrorCodeIsBadRequest()
        {
            HttpResponseMessage.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Then(@"payment gateway returns a successful response")]
        public void ThenPaymentGatewayReturnsASuccessfulResponse()
        {
            HttpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
        }
        #endregion

    }
}
