using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Models
{
    public class Amount
    {
        [Required]
        public double Total { get; set; }
        public string Currency { get; set; }

        public Amount()
        {
            Currency = "EUR";
        }
        public Amount(double total, string currency)
        {
            Total = total;
            Currency = currency;
        }
    }
}
