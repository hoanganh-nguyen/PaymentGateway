using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Models
{
    public class PaymentResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool Status { get; set; }
        public PaymentResponse()
        {

        }

        public PaymentResponse(Guid id, bool status)
        {
            Id = id;
            Status = status;

        }
    }
}
