using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcquiringBank.Domain.Interfaces;
using AcquiringBank.Domain.Models;
using PaymentGateway.Models;

namespace AcquiringBank.Application
{
    public class SimulatedCardNetworkHandler: ICardNetworkHandler
    {
        public async Task<PaymentResponse> ForwardToProcessAsync(CardType cardType, PaymentRequest request)
        {
            bool status;
            switch (cardType)
            {
                case CardType.Visa:
                    status = request.Amount.Total < 100;
                    break;
                case CardType.MasterCard:
                    status = request.Amount.Total < 200;
                    break;
                case CardType.AmericanExpress:
                    status = request.Amount.Total < 1500;
                    break;
                default:
                    status = request.Amount.Total < 20;
                    break;
            }
            return await Task.Run(() => new PaymentResponse(Guid.NewGuid(), status));
        }
    }
}
