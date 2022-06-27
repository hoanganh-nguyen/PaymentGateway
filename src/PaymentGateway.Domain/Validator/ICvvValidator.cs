namespace AcquiringBank.Domain.Validator
{
    public interface ICvvValidator
    {
        bool IsValid(string cvv);
    }
}
