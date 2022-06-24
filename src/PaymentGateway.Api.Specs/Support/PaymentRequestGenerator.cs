using PaymentGateway.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Specs.Support
{
    internal class PaymentRequestGenerator
    {
        public PaymentRequest BuildBadPaymentRequest()
        {
            return new PaymentRequest();
        }
        public PaymentRequest BuildPaymentRequestWithInvalidCreditCard()
        {
            return new PaymentRequest();
        }

        public PaymentRequest BuildValidPaymentRequest()
        {
            return new PaymentRequest();
        }
    }
}
