using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensorService.Application.Interfaces;
using SensorService.Domain.Entities;

namespace SensorService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleEventsController : ControllerBase
    {
        private readonly IVehicleEventRepository _repo;
        public VehicleEventsController(IVehicleEventRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("vehicle-entry")]
        public IActionResult RegisterVehicle([FromBody] VehicleEvent vehicleEvent)
        {
            vehicleEvent.Timestamp = DateTime.UtcNow;
            _repo.Add(vehicleEvent);
            return Ok(vehicleEvent);
        }

        [HttpGet("events")]
        public IActionResult GetAllEvents()
        {
            return Ok(_repo.GetAll());
        }
    }
}

