using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Models;
using PaymentGateway.Api.Attribute;
using PaymentGateway.Domain.Validator;

namespace PaymentGateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRequestValidator _validator;
        private readonly IPaymentGateway _paymentGateway;

        public PaymentController(IPaymentRequestValidator validator, IPaymentGateway paymentGateway)
        {
            _validator = validator;
            _paymentGateway = paymentGateway;
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentInfo>> Get(string id)
        {
            if(!Guid.TryParse(id, out var guid))
                return BadRequest();
            var ret =  await _paymentGateway.RetrievePaymentDetailsAsync(guid);
            if (ret == null)
                return NotFound();
            return Ok(ret);
        }

        // POST api/<PaymentController>
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<PaymentResponse>> PostAsync([FromBody] PaymentRequest request)
        {
            if (!_validator.IsValid(request))
            {
                return BadRequest();
            }
            var response = await _paymentGateway.ProcessPaymentAsync(request);
            if (!response.Status)
            {
                return UnprocessableEntity(response);
            }
            return Ok(response);
        }
    }
}
