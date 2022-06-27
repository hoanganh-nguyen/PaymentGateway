using PaymentGateway.Models;

namespace PaymentGateway.Domain.Validator
{
    public interface ICreditCardValidator
    {
        bool IsValid(CreditCard card);
    }
}
