using PaymentGateway.Models;

namespace PaymentGateway.Domain.Interfaces
{
    public interface IPaymentGateway
    {
        Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request);
        Task<PaymentInfo?> RetrievePaymentDetailsAsync(Guid id);
    }
}
