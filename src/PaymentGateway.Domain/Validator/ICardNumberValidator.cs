namespace PaymentGateway.Domain.Validator
{
    public interface ICardNumberValidator
    {
        bool IsValid(string cardNumber);
    }
}
