using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGateway.Api.Specs.Support;
using PaymentGateway.Models;
using PaymentGateway.TestingSupport.ExampleGenerator;

namespace PaymentGateway.Api.Specs.StepDefinitions
{
    [Binding]
    public class PaymentBaseStepDefinitions: IntegrationTestBase
    {
        protected PaymentRequest Request;

        protected PaymentResponse Response;

        protected HttpResponseMessage HttpResponseMessage;

        protected string PaymentEndpoint { get; set; }

        public PaymentBaseStepDefinitions()
        {
            PaymentEndpoint = $"{ApiUri}api/Payment";
        }


    }
}
