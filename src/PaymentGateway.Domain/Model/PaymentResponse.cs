using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Model
{
    public class PaymentResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string ErrorMessage{ get; set; }
        public PaymentResponse()
        {

        }
    }
}
