using PaymentGateway.Models;

namespace PaymentGateway.Domain.Validator
{
    public interface IPaymentRequestValidator
    {
        bool IsValid(PaymentRequest req);
    }
}
