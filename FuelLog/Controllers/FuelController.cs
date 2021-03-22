using FuelLog.Entities;
using FuelLog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog.Controllers
{
    [ApiController]
    public class FuelController : ControllerBase
    {
        private readonly IFuelRepository _fuelRepository;

        public FuelController(IFuelRepository fuelRepository)
        {
            _fuelRepository = fuelRepository;
        }

        [HttpGet("api/fuelLogs")]
        [Authorize]
        public IActionResult GetFuelLogs()
        {
            var fuels = _fuelRepository.GetFuels();
            return Ok(fuels);
        }

        [HttpGet("api/fuelLog/{id}")]
        [Authorize]
        public IActionResult GetFuelLog(int id)
        {
            var fuel = _fuelRepository.GetFuel(id);

            if(fuel == null)
            {
                return NotFound();
            }

            return Ok(fuel);
        }

        [HttpPut("api/fuelLog/{id}")]
        [Authorize]
        public IActionResult UpdateFuelLog(int id, [FromBody] Fuel fuel)
        {
            if (fuel == null)
            {
                return NotFound();
            }

            _fuelRepository.UpdateFuel(id, fuel);

            return Ok(fuel);
        }

        [HttpPost("api/fuelLog")]
        [Authorize]
        public int AddFuelLog([FromBody] Fuel fuel)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentNullException(nameof(fuel));
            }
            _fuelRepository.AddFuel(fuel);
            return fuel.Id;
        }

        [HttpDelete("api/fuelLog/{id}")]
        [Authorize]
        public IActionResult DeleteFuelLog(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Not valid Id");
            }
            _fuelRepository.DeleteFuel(id);
            return Ok();
        }

    }
}
