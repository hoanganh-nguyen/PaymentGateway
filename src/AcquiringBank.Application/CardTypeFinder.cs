using System.Text.RegularExpressions;
using AcquiringBank.Domain.Interfaces;
using AcquiringBank.Domain.Models;

namespace AcquiringBank.Application
{
    /// <summary>
    /// Rules: https://www.regular-expressions.info/creditcard.html
    /// </summary>
    public class CardTypeFinder: ICardTypeFinder
    {
        public CardType FindType(string cardNumber)
        {
            
            if (Regex.Match(cardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
            {
                return CardType.Visa;
            }

            if (Regex.Match(cardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
            {
                return CardType.MasterCard;
            }

            if (Regex.Match(cardNumber, @"^3[47][0-9]{13}$").Success)
            {
                return CardType.AmericanExpress;
            }

            if (Regex.Match(cardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$").Success)
            {
                return CardType.Discover;
            }

            if (Regex.Match(cardNumber, @"^(?:2131|1800|35\d{3})\d{11}$").Success)
            {
                return CardType.JCB;
            }

            throw new Exception("Unknown card.");
        }
    }
}
