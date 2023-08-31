using AllwinPlanning.Core.Entities;
using AllwinPlanning.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AllwinPlanning.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IAllwinRepository _repository;

        public DriverController(IAllwinRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "Stops")]
        public async Task<Stops> GetStops([FromQuery] Guid areaId, [FromQuery] Guid vehicleId, [FromQuery] int weekday)
        {
            var depot = await _repository.GetDepot(areaId);
            var pickups = await _repository.GetPickups(vehicleId);
            var deliveries = await _repository.GetDeliveries(vehicleId, weekday);

            return new Stops()
            {
                Depot = depot,
                Pickups = pickups,
                Deliveries = deliveries
            };
        }
    }
}
