using AcquiringBank.Domain.Validator;
using PaymentGateway.Models;
using PaymentGateway.Domain.Validator;

namespace PaymentGateway.Application.Validator
{
    public class CreditCardValidator : ICreditCardValidator
    {
        private readonly ICardNumberValidator _cardNumberValidator;
        private readonly ICvvValidator _cvvValidator;
        public CreditCardValidator(ICardNumberValidator cardNumberValidator, ICvvValidator cvvValidator)
        {
            _cardNumberValidator = cardNumberValidator;
            _cvvValidator = cvvValidator;

        }
        public bool IsValid(CreditCard card)
        {
            if (new DateTime(card.ExpiryYear, card.ExpiryMonth, 1) < DateTime.Today)
                return false;
            return _cardNumberValidator.IsValid(card.CardNumber) && _cvvValidator.IsValid(card.Cvv);
        }
    }
}
