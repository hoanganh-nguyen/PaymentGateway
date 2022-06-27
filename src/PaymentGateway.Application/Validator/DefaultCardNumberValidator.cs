using PaymentGateway.Domain.Validator;

namespace PaymentGateway.Application.Validator
{
    public class DefaultCardNumberValidator:ICardNumberValidator
    {
        public bool IsValid(string cardNumber)
        {
            cardNumber = Standardize(cardNumber);
            var nDigits = cardNumber.Length;

            var nSum = 0;
            var isSecond = false;
            for (var i = nDigits - 1; i >= 0; i--)
            {
                var d = cardNumber[i] - '0';
                if (isSecond == true)
                    d = d * 2;
                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }

        private string Standardize(string cardNumber)
        {
            return cardNumber.Replace(" ", "").Replace("-", "");
        }
    }
}
