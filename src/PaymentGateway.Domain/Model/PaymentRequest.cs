using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Model
{
    public class PaymentRequest
    {
        public CreditCard CardInfo { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
        public PaymentRequest()
        {

        }
    }
}
