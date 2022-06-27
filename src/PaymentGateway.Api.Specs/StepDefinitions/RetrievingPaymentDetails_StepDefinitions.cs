using System.Net;
using PaymentGateway.Api.Specs.Support;
using PaymentGateway.Models;
using PaymentGateway.TestingSupport.ExampleGenerator;
using TechTalk.SpecFlow.CommonModels;

namespace PaymentGateway.Api.Specs.StepDefinitions
{
    [Binding]
    public class RetrievingPaymentDetailsStepDefinitions: PaymentBaseStepDefinitions
    {
        private Guid _paymentId;
        private PaymentInfo _paymentInfo;
        [Given(@"A previous sucessful payment request")]
        public void GivenAPreviousSucessfulPaymentRequest()
        {
            var request = PaymentRequestGenerator.ValidPaymentRequest("4169773331987017", 75);
            var response = Task.Run(async () => await Client!.PostAsync(PaymentEndpoint, JsonData(request))).Result;
            response.IsSuccessStatusCode.Should().BeTrue();
            _paymentId = ObjectData<PaymentResponse>(response.Content.ReadAsStringAsync().Result)!.Id;
        }

        [When(@"I request to retrieve details")]
        public void WhenIRequestToRetrieveDetails()
        {
            string endpoint = $"{PaymentEndpoint}/{_paymentId}";
            HttpResponseMessage =  Client!.GetAsync(endpoint).Result;
        }

        [Then(@"the payment gateway returns a successful response")]
        public void ThenThePaymentGatewayReturnsASuccessfulResponse()
        {
            HttpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
        }

        [Then(@"the response is matched with the previously payment made")]
        public void ThenTheResponseIsMatchedWithThePreviouslyPaymentMade()
        {
            var json = HttpResponseMessage.Content.ReadAsStringAsync().Result;
            var obj = ObjectData<PaymentInfo>(json);
            obj.Id.Should().Be(_paymentId);
        }

        [Given(@"A previous unsucessful payment request")]
        public void GivenAPreviousUnsucessfulPaymentRequest()
        {
            _paymentId = Guid.NewGuid();
        }

        [Then(@"the payment gateway returns an unsuccessful response")]
        public void ThenThePaymentGatewayReturnsAnUnsuccessfulResponse()
        {
            HttpResponseMessage.IsSuccessStatusCode.Should().BeFalse();
        }

        [Then(@"the error is not found")]
        public void ThenTheErrorIsNotFound()
        {
            HttpResponseMessage.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
