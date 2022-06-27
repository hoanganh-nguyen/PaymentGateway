using PaymentGateway.Domain.Validator;

namespace PaymentGateway.Application.Validator
{
    public class DefaultSupportedCurrencyValidator: ISupportedCurrencyValidator
    {
        public List<string> SupportedCurrencyList = new List<string>() {"USD", "EUR", "GBP"};

        public bool IsValid(string currency)
        {
            return SupportedCurrencyList.Contains(currency);
        }
    }
}
