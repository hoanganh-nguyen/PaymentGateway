using PaymentGateway.Models;

namespace PaymentGateway.TestingSupport
{
    public class CardInfoGenerator
    {
        public static CreditCard GoodOne()
        {
            return new CreditCard()
            {
                CardNumber = "5555555555554444",
                Cvv = "457",
                ExpiryMonth = 12,
                ExpiryYear = DateTime.Now.Year + 2
            };

        }

        public static CreditCard GoodOne(string cardNumber)
        {
            return new CreditCard()
            {
                CardNumber = cardNumber,
                Cvv = "457",
                ExpiryMonth = 12,
                ExpiryYear = DateTime.Now.Year + 2
            };

        }
        public static CreditCard BadOne()
        {
            return new CreditCard()
            {
                CardNumber = "5555555555554444",
                Cvv = "457",
                ExpiryMonth = DateTime.Now.Month - 1,
                ExpiryYear = DateTime.Now.Year
            };

        }
    }
}
