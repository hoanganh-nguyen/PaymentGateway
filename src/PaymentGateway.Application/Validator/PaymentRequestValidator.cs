
using PaymentGateway.Domain.Validator;
using PaymentGateway.Models;

namespace PaymentGateway.Application.Validator
{
    public class PaymentRequestValidator:IPaymentRequestValidator
    {
        private readonly ISupportedCurrencyValidator _currencyValidator;
        private readonly ICreditCardValidator _creditCardValidator;

        public PaymentRequestValidator(ISupportedCurrencyValidator currencyValidator, ICreditCardValidator creditCardValidator)
        {
            _currencyValidator = currencyValidator;
            _creditCardValidator = creditCardValidator;
        }

        public bool IsValid(PaymentRequest req)
        {
            if (req.Amount?.Total < 0)
                return false;
            if (!_currencyValidator.IsValid(req.Amount!.Currency))
                return false;
            return _creditCardValidator.IsValid(req.CardInfo);
        }
    }


}
