using AcquiringBank.Application;
using AcquiringBank.Domain.Interfaces;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Models;

namespace PaymentGateway.LocalAcquiringBank
{
    public class LocalAcquiringBank: IAcquiringBankHandler
    {
        private readonly ICardTypeFinder _cardTypeFinder;
        private readonly ICardNetworkHandler _cardNetworkHandler;

        // For Dependency Injection usage later
        //public LocalAcquiringBank(ICardTypeFinder cardTypeFinder, ICardNetworkHandler cardNetworkHandler)
        //{
        //    _cardTypeFinder = cardTypeFinder;
        //    _cardNetworkHandler = cardNetworkHandler;
        //}

        public LocalAcquiringBank()
        {
            _cardTypeFinder = new CardTypeFinder();
            _cardNetworkHandler = new SimulatedCardNetworkHandler();
        }

        public async Task<PaymentResponse> ProcessAsync(PaymentRequest request)
        {
            try
            {
                var cardType = _cardTypeFinder.FindType(request.CardInfo.CardNumber);
               return await _cardNetworkHandler.ForwardToProcessAsync(cardType, request);
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new PaymentResponse(Guid.NewGuid(), false));

            }
        }
    }
}