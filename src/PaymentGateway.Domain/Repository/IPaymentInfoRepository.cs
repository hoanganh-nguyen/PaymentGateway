using PaymentGateway.Models;

namespace PaymentGateway.Domain.Repository
{
    public interface IPaymentInfoRepository
    {
        Task<PaymentInfo?> GetAsync(Guid id);
        Task<bool> AddAsync(PaymentInfo info);
    }
}
