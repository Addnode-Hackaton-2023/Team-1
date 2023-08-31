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
	public class DeliveryController : Controller
	{
		private readonly ILogger<DeliveryController> _logger;
		private readonly IAllwinRepository _repository;
		public DeliveryController(ILogger<DeliveryController> logger, IAllwinRepository repository)
		{
			_logger = logger;
			_repository = repository;
		}

		[HttpGet]
		public async Task<List<DeliveryModel>> GetAll()
		{
			return (await _repository.GetAllDeliveries()).Select(DeliveryModel.Create).ToList();
		}

		[HttpGet("{gid}")]
		public async Task<DeliveryModel> GetDelivery(Guid gid)
		{
			return DeliveryModel.Create(await _repository.GetDelivery(gid));
		}

		[HttpPost]
		public async Task<DeliveryModel> PostAsync([FromBody] DeliveryDto DeliveryDto)
		{
			var Delivery = new Delivery
			{
				DeliveryName = DeliveryDto.DeliveryName,
				ContactName = DeliveryDto.ContactName,
				ContactPhone = DeliveryDto.ContactPhone,
				VehicleId = DeliveryDto.VehicleId,
				StopTime = DeliveryDto.StopTime,
				DeliveryDays = DeliveryDto.DeliveryDays,
				Shape = GeometryHelper.CreatePoint(DeliveryDto.Shape)
			};

			return DeliveryModel.Create(await _repository.AddDelivery(Delivery));
		}

		[HttpPut]
		public async Task<DeliveryModel> PutAsync([FromBody] DeliveryDto DeliveryDto)
		{
			var Delivery = await _repository.GetDelivery(DeliveryDto.Gid);

			Delivery.DeliveryName = DeliveryDto.DeliveryName;
			Delivery.ContactName = DeliveryDto.ContactName;
			Delivery.ContactPhone = DeliveryDto.ContactPhone;
			Delivery.VehicleId = DeliveryDto.VehicleId;
			Delivery.StopTime = DeliveryDto.StopTime;
			Delivery.DeliveryDays = DeliveryDto.DeliveryDays;
			Delivery.Shape = GeometryHelper.CreatePoint(DeliveryDto.Shape);

			return DeliveryModel.Create(await _repository.AddDelivery(Delivery));
		}

		[HttpDelete("{gid}")]
		public async Task DeleteAsync(Guid gid)
		{
			await _repository.DeleteDelivery(gid);
		}
	}
}
