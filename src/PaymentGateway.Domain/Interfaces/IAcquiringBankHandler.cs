using PaymentGateway.Models;


namespace PaymentGateway.Domain.Interfaces
{
    public interface IAcquiringBankHandler
    {
        Task<PaymentResponse> ProcessAsync(PaymentRequest request);
    }
}
