using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Booking;
using Api.Services.Services.PaymentServices;

namespace Api.Application.Controller.Payment
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }
            try
            {
                var payments = await _service.GetAll();
                return Ok(payments);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetPaymentId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }
            try
            {
                var payment = await _service.Get(id);
                if (payment == null)
                {
                    return NotFound(); // 404
                }
                return Ok(payment); // 200
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PaymentEntity payment)
        {
            if (payment == null)
            {
                return BadRequest("Payment data is required.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }

            try
            {
                var result = await _service.Post(payment);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetPaymentId", new { id = result.Id })), result); // 201
                }
                else
                {
                    return BadRequest("Failed to create payment."); // 400
                }
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] PaymentEntity payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }
            try
            {
                var existingPayment = await _service.Get(id);
                if (existingPayment == null)
                {
                    return NotFound(); // 404
                }

                existingPayment.BookingId = payment.BookingId;
                existingPayment.PaymentDate = payment.PaymentDate;
                existingPayment.PaymentMethod = payment.PaymentMethod;

                var updatedPayment = await _service.Put(existingPayment);
                return Ok(updatedPayment); // 200
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("payment-methods")]
        public ActionResult<IEnumerable<string>> GetPaymentMethods()
        {
            var methods = _service.GetPaymentMethods();
            return Ok(methods);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            if (!result)
            {
                return NotFound(); 
            }

            return NoContent(); 
        }
    }
}
