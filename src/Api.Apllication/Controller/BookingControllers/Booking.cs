using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Booking;

namespace Api.Application.Controller.BookingControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
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
                var bookings = await _service.GetAll();
                return Ok(bookings);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetBookingId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }
            try
            {
                var booking = await _service.Get(id);
                if (booking == null)
                {
                    return NotFound(); // 404
                }
                return Ok(booking); // 200
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }
            try
            {
                var result = await _service.Delete(id);
                if (!result)
                {
                    return NotFound(); // 404
                }
                return NoContent(); // 204
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookingEntity booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }
            try
            {
                var result = await _service.Post(booking);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetBookingId", new { id = result.Id })), result); // 201
                }
                else
                {
                    return BadRequest(); // 400
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] BookingEntity booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }
            try
            {
                var existingBooking = await _service.Get(id);
                if (existingBooking == null)
                {
                    return NotFound(); // 404
                }

                existingBooking.PackageId = booking.PackageId;
                existingBooking.UserId = booking.UserId;
                existingBooking.BookingDate = booking.BookingDate;

                var updatedBooking = await _service.Put(existingBooking);
                return Ok(updatedBooking); // 200
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
