using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Model
{
    public class PaymentDetails
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public CreditCard Card { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public DateTime LastUpdate { get; set; }
        public PaymentDetails()
        {

        }
    }
}
