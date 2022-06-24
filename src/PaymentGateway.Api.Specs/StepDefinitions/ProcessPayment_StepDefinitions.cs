using System;
using TechTalk.SpecFlow;

namespace PaymentGateway.Api.Specs.StepDefinitions
{
    [Binding]
    public class ProcessPayment_StepDefinitions
    {
        #region Given
        [Given(@"Shopper provides a bad payment request")]
        public void GivenShopperProvidesABadPaymentRequest()
        {
            throw new PendingStepException();
        }

        [Given(@"Shopper provides an invalid credit card")]
        public void GivenShopperProvidesAnInvalidCreditCard()
        {
            throw new PendingStepException();
        }

        [Given(@"Shopper provides a valid payment request")]
        public void GivenShopperProvidesAValidPaymentRequest()
        {
            throw new PendingStepException();
        }

        #endregion Given

        #region When

        [When(@"submitting a payment request")]
        public void WhenSubmittingAPaymentRequest()
        {
            throw new PendingStepException();
        }
        #endregion

        #region Then
        [Then(@"the error code is unprocessable entity")]
        public void ThenTheErrorCodeIsUnprocessableEntity()
        {
            throw new PendingStepException();
        }

        [Then(@"payment gateway returns a unsuccessfule response")]
        public void ThenPaymentGatewayReturnsAUnsuccessfuleResponse()
        {
            throw new PendingStepException();
        }

        [Then(@"the error code is bad request")]
        public void ThenTheErrorCodeIsBadRequest()
        {
            throw new PendingStepException();
        }

        [Then(@"payment gateway returns a successfule response")]
        public void ThenPaymentGatewayReturnsASuccessfuleResponse()
        {
            throw new PendingStepException();
        }
        #endregion

    }
}
