using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Booking;
using Microsoft.AspNetCore.Mvc;

namespace Api.Apllication.Controller.BookingControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UfController : ControllerBase
    {
        private readonly IUfService _ufService;

        public UfController(IUfService ufService)
        {
            _ufService = ufService;
        }

          [HttpGet]
        public async Task<ActionResult<IEnumerable<UfEntity>>> GetAll()
        {
            var packages = await _ufService.GetAll();
            return Ok(packages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UfEntity>> Get(Guid id)
        {
            var uf = await _ufService.Get(id);
            if (uf == null)
            {
                return NotFound();
            }

            return Ok(uf);
        }
    }

}