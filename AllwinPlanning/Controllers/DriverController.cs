using AllwinPlanning.Core.Entities;
using AllwinPlanning.Core.Interfaces;
using AllwinPlanning.Model;
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
		public async Task<StopsModel> GetStops([FromQuery] Guid areaId, [FromQuery] Guid vehicleId, [FromQuery] int weekday)
		{
			var depot = await _repository.GetDepot(areaId);
			var pickups = await _repository.GetPickups(vehicleId);
			var deliveries = await _repository.GetDeliveries(vehicleId, weekday);

			return new StopsModel()
			{
				Depot = DepotModel.Create(depot),
				Pickups = pickups.Select(PickupModel.Create),
				Deliveries = deliveries.Select(DeliveryModel.Create)
			};
		}

        [HttpPost(Name = "AddStopLog")]
		public async Task<ActionResult> AddStopLogAsync(StopLog stopLog)
		{
			try
			{
				await _repository.AddStopLog(stopLog);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
			return Ok();
		}
    }
}
