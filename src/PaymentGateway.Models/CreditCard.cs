using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Models
{
    public class CreditCard
    {
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string Cvv { get; set; }
        [Required]
        public int ExpiryMonth { get; set; }
        [Required]
        public int ExpiryYear { get; set; }

        public CreditCard(){}
        public CreditCard(string cardNumber, string cvv, int expiryMonth, int expiryYear)
        {
            CardNumber = cardNumber;
            Cvv = cvv;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
        }
    }
}
