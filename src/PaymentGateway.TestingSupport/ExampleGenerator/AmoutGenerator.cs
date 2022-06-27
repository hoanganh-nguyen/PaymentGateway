using PaymentGateway.Models;

namespace PaymentGateway.TestingSupport.ExampleGenerator
{
    internal class AmoutGenerator
    {
        internal static Amount NegativeAmountWithSupportedCurrency()
        {
            return new Amount(-100, "USD");
        }

        internal static Amount PositiveAmountWithSupportedCurrency()
        {
            return PositiveAmountWithSupportedCurrency(100);
        }
        internal static Amount PositiveAmountWithSupportedCurrency(double amount)
        {
            return new Amount(amount, "USD");
        }
        internal static Amount PositiveAmountWithUnsupportedCurrency()
        {
            return new Amount(100, "XXX");
        }
    }
}
