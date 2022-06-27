using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Domain.Repository;
using PaymentGateway.Domain.Validator;
using PaymentGateway.Models;

namespace PaymentGateway.Application.Processor
{
    public class PaymentProcessor : IPaymentGateway
    {
        private readonly IAcquiringBankHandler _acquiringBankHandler;
        private readonly IPaymentInfoRepository _repository;
        public PaymentProcessor(IAcquiringBankHandler acquiringBankHandler, IPaymentInfoRepository paymentInfoRepository)
        {
            _acquiringBankHandler = acquiringBankHandler;
            _repository = paymentInfoRepository;
        }
        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request)
        {
            var ret = new PaymentResponse() { Id = Guid.NewGuid(), Status = false };
            try
            {
                ret = await _acquiringBankHandler.ProcessAsync(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ret.Status = false;
            }
            finally
            {
                var paymentInfo = new PaymentInfo()
                {
                    Id = ret.Id,
                    Card = request.CardInfo,
                    Amount = request.Amount,
                    Status = ret.Status,
                    LastUpdate = DateTime.Now.ToUniversalTime()
                };
                await _repository.AddAsync(paymentInfo);

            }
            return ret;

        }

        public async Task<PaymentInfo?> RetrievePaymentDetailsAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }
    }
}