using AcquiringBank.Domain.Models;
using PaymentGateway.Models;

namespace AcquiringBank.Domain.Interfaces
{
    public interface ICardNetworkHandler
    {
        Task<PaymentResponse> ForwardToProcessAsync(CardType cardType, PaymentRequest request);
    }
}
