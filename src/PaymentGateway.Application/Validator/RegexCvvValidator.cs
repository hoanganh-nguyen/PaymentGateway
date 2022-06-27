using System.Text.RegularExpressions;
using AcquiringBank.Domain.Validator;

namespace PaymentGateway.Application.Validator
{
    public class RegexCvvValidator : ICvvValidator
    {
        private const string CvvPattern = "^[0-9]{3,4}$";
        public bool IsValid(string cvv)
        {
            var rule = new Regex(CvvPattern);
            return rule.IsMatch(cvv);
        }
    }
}
