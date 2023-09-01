using AllwinPlanning.Application;
using AllwinPlanning.Core.Entities;
using AllwinPlanning.Core.Interfaces;
using AllwinPlanning.Dto;
using AllwinPlanning.Model;
using Microsoft.AspNetCore.Mvc;


namespace AllwinPlanning.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class PickupController : Controller
	{
		private readonly ILogger<PickupController> _logger;
		private readonly IAllwinRepository _repository;
		public PickupController(ILogger<PickupController> logger, IAllwinRepository repository)
		{
			_logger = logger;
			_repository = repository;
		}


		[HttpGet]
		public async Task<List<PickupModel>> GetAll()
		{
			return (await _repository.GetAllPickups()).Select(PickupModel.Create).ToList();
		}
		[HttpGet("{gid}")]
		public async Task<PickupModel> GetPickup(Guid gid)
		{
			return PickupModel.Create(await _repository.GetPickup(gid));
		}

		[HttpPost]
		public async Task<PickupModel> PostAsync([FromBody] PickupDto pickupDto)
		{
			var vehicle = (await _repository.GetVehicles()).Find(v => v.Gid == pickupDto.VehicleId);
			var pickup = new Pickup
			{
				Active = pickupDto.Active,
				AvarageStoptime = pickupDto.AvarageStoptime,
				AvarageVolume = pickupDto.AvarageVolume,
				ClosingHour = pickupDto.ClosingHour,
				ContactName = pickupDto.ContactName,
				ContactPhoneNumber = pickupDto.ContactPhoneNumber,
				Gid = pickupDto.Gid,
				OpeningHour = pickupDto.OpeningHour,
				PickupName = pickupDto.PickupName,
				PickupType = pickupDto.PickupType,
				VehicleId = pickupDto.VehicleId,
				Shape = GeometryHelper.CreatePoint(pickupDto.Shape)
			};
			vehicle?.Pickups.Add(pickup);
			_repository.Save();

			return PickupModel.Create(pickup);
		}

		[HttpPut]
		public async Task<PickupModel> PutAsync([FromBody] PickupDto pickupDto)
		{
			var pickup = await _repository.GetPickup(pickupDto.Gid);

			pickup.Active = pickupDto.Active;
			pickup.AvarageStoptime = pickupDto.AvarageStoptime;
			pickup.AvarageVolume = pickupDto.AvarageVolume;
			pickup.ClosingHour = pickupDto.ClosingHour;
			pickup.ContactName = pickupDto.ContactName;
			pickup.ContactPhoneNumber = pickupDto.ContactPhoneNumber;
			pickup.Gid = pickupDto.Gid;
			pickup.OpeningHour = pickupDto.OpeningHour;
			pickup.PickupName = pickupDto.PickupName;
			pickup.PickupType = pickupDto.PickupType;
			pickup.VehicleId = pickupDto.VehicleId;
			pickup.Shape = GeometryHelper.CreatePoint(pickupDto.Shape);
			_repository.Save();

			return PickupModel.Create(pickup);
		}

		[HttpDelete("{gid}")]
		public async Task DeleteAsync(Guid gid)
		{
			await _repository.DeletePickup(gid);
		}
	}
}
