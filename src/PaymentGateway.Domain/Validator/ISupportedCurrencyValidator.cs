namespace PaymentGateway.Domain.Validator
{
    public interface ISupportedCurrencyValidator
    {
        bool IsValid(string currency);

    }
}
