using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Models
{
    public class PaymentRequest
    {
        [Required]
        public CreditCard CardInfo { get; set; }
        [Required]
        public Amount Amount { get; set; }

        public PaymentRequest()
        {
            CardInfo = new CreditCard();
            Amount = new Amount();
        }
        public PaymentRequest(CreditCard cardInfo, Amount amount)
        {
            CardInfo = cardInfo;
            Amount = amount;
        }
    }
}
