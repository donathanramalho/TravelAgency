// Caminho: Api.Application/Controllers/PackageController.cs

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Booking;
using Api.Domain.Interfaces.Services.Payment;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _service;
        private readonly IPriceCalculator _priceCalculator;
        private readonly IUfService _ufService;

        public PackageController(IPackageService service, IPriceCalculator priceCalculator, IUfService ufService)
        {
            _service = service;
            _priceCalculator = priceCalculator;
            _ufService = ufService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageEntity>>> GetAll()
        {
            var packages = await _service.GetAll();
            return Ok(packages);
        }

        [HttpGet("{id}", Name = "GetPackageById")]
        public async Task<ActionResult<PackageEntity>> Get(Guid id)
        {
            var package = await _service.Get(id);
            if (package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }

        [HttpPost]
        public async Task<ActionResult<PackageEntity>> Post([FromBody] PackageEntity package)
        {
            var ufOrigem = await _ufService.Get(package.UfIdOrigem);
            if (ufOrigem == null)
            {
                return BadRequest("Invalid UfIdOrigem");
            }

            var ufDestino = await _ufService.Get(package.UfIdDestino);
            if (ufDestino == null)
            {
                return BadRequest("Invalid UfIdDestino");
            }

            decimal price = Math.Round(_priceCalculator.CalculatePrice(package), 2);
            package.SetPrice(price);

            try
            {
                var createdPackage = await _service.Post(package);
                return CreatedAtRoute("GetPackageById", new { id = createdPackage.Id }, createdPackage);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PackageEntity>> Put(Guid id, [FromBody] PackageEntity package)
        {
            var existingPackage = await _service.Get(id);
            if (existingPackage == null)
            {
                return NotFound();
            }

            existingPackage.MunicipioOrigem = package.MunicipioOrigem;
            existingPackage.UfIdOrigem = package.UfIdOrigem;
            existingPackage.MunicipioDestino = package.MunicipioDestino;
            existingPackage.UfIdDestino = package.UfIdDestino;
            existingPackage.Quantity = package.Quantity;
            existingPackage.StartDate = package.StartDate;
            existingPackage.EndDate = package.EndDate;
            decimal price = Math.Round(_priceCalculator.CalculatePrice(existingPackage), 2);
            existingPackage.SetPrice(price);

            try
            {
                var updatedPackage = await _service.Put(existingPackage);
                return Ok(updatedPackage);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
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
