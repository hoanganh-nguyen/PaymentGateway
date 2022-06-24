using System;
using TechTalk.SpecFlow;

namespace PaymentGateway.Api.Specs.StepDefinitions
{
    [Binding]
    public class RetrievingPaymentDetails_StepDefinitions
    {
        [Given(@"A previous sucessful payment request")]
        public void GivenAPreviousSucessfulPaymentRequest()
        {
            throw new PendingStepException();
        }

        [When(@"I request to retrieve details")]
        public void WhenIRequestToRetrieveDetails()
        {
            throw new PendingStepException();
        }

        [Then(@"the payment gateway returns a successful response")]
        public void ThenThePaymentGatewayReturnsASuccessfulResponse()
        {
            throw new PendingStepException();
        }

        [Then(@"the response is matched with the previously payment made")]
        public void ThenTheResponseIsMatchedWithThePreviouslyPaymentMade()
        {
            throw new PendingStepException();
        }

        [Given(@"A previous unsucessful payment request")]
        public void GivenAPreviousUnsucessfulPaymentRequest()
        {
            throw new PendingStepException();
        }

        [Then(@"the payment gateway returns an unsuccessful response")]
        public void ThenThePaymentGatewayReturnsAnUnsuccessfulResponse()
        {
            throw new PendingStepException();
        }

        [Then(@"the error is not found")]
        public void ThenTheErrorIsNotFound()
        {
            throw new PendingStepException();
        }
    }
}
