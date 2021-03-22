using FuelLog.Entities;
using FuelLog.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog.Controllers
{
    public class CostController : ControllerBase
    {
        private readonly ICostRepository _costRepository;

        public CostController(ICostRepository costRepository)
        {
            _costRepository = costRepository;
        }

        [HttpGet("api/costLogs")]
        public IActionResult GetCostLogs()
        {
            var costs = _costRepository.GetCosts();
            return Ok(costs);
        }

        [HttpGet("api/costLog/{id}")]
        public IActionResult GetCostLog(int id)
        {
            var cost = _costRepository.GetCost(id);

            if (cost == null)
            {
                return NotFound();
            }

            return Ok(cost);
        }

        [HttpPost("api/costLog")]
        public int CreateCost([FromBody] Cost cost)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentNullException(nameof(cost));
            }
            _costRepository.AddCost(cost);
            return cost.Id;
        }

        [HttpPut("api/costLog/{id}")]
        public void UpdateCost([FromBody] Cost cost)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentNullException(nameof(cost));
            }

            if(cost.Id <= 0)
            {
                throw new ArgumentException("Cost Id must be > 0");
            }
            _costRepository.UpdateCost(cost);
        }

        [HttpDelete("api/costLog/{id}")]
        public IActionResult DeleteCost(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not valid Id");
            }
            _costRepository.DeleteCost(id);

            return Ok();
        }
    }
}
