using AcquiringBank.Domain.Models;

namespace AcquiringBank.Domain.Interfaces
{
    public interface ICardTypeFinder
    {
        CardType FindType(string cardNumber);
    }
}
