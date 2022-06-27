using PaymentGateway.Models;

namespace PaymentGateway.TestingSupport.ExampleGenerator
{
    public class PaymentRequestGenerator
    {
        public static PaymentRequest PaymentRequestWithNegativeAmount()
        {
            return new PaymentRequest()
            {
                CardInfo = CardInfoGenerator.GoodOne(),
                Amount = AmoutGenerator.NegativeAmountWithSupportedCurrency()
            };
        }
        public static PaymentRequest PaymentRequestWithUnknownCurrency()
        {
            return new PaymentRequest()
            {
                CardInfo = CardInfoGenerator.GoodOne(),
                Amount = AmoutGenerator.PositiveAmountWithUnsupportedCurrency()
            };
        }
        public static PaymentRequest PaymentRequestWithInvalidCreditCard()
        {
            return new PaymentRequest()
            {
                CardInfo = CardInfoGenerator.BadOne(),
                Amount = AmoutGenerator.PositiveAmountWithSupportedCurrency()
            };
        }

        public static PaymentRequest ValidPaymentRequest()
        {
            return new PaymentRequest()
            {
                CardInfo = CardInfoGenerator.GoodOne(),
                Amount = AmoutGenerator.PositiveAmountWithSupportedCurrency()
            };
        }

        public static PaymentRequest ValidPaymentRequest(string cardNumber, double amount)
        {
            return new PaymentRequest()
            {
                CardInfo = CardInfoGenerator.GoodOne(cardNumber),
                Amount = AmoutGenerator.PositiveAmountWithSupportedCurrency(amount)
            };
        }
    }
}
