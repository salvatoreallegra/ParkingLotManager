using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensorService.Api.Services;
using SensorService.Application.Interfaces;
using SensorService.Domain.Entities;

namespace SensorService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleEventsController : ControllerBase
    {
        private readonly IVehicleEventRepository _repo;
        private readonly SqsSender _sqs;
        public VehicleEventsController(IVehicleEventRepository repo, SqsSender sqs)
        {
            _repo = repo;
            _sqs = sqs;
        }

        [HttpPost("vehicle-entry")]
        public async Task<IActionResult> RegisterVehicle([FromBody] VehicleEvent vehicleEvent)
        {
            vehicleEvent.Timestamp = DateTime.UtcNow;
            _repo.Add(vehicleEvent);

            await _sqs.SendVehicleEventAsync(vehicleEvent);

            return Ok(vehicleEvent);
        }

        [HttpGet("events")]
        public IActionResult GetAllEvents()
        {
            return Ok(_repo.GetAll());
        }
    }
}

