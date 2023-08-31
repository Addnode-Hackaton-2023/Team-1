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
	public class DepotController : Controller
	{
		private readonly ILogger<DepotController> _logger;
		private readonly IAllwinRepository _repository;
		public DepotController(ILogger<DepotController> logger, IAllwinRepository repository)
		{
			_logger = logger;
			_repository = repository;
		}

		[HttpGet]
		public async Task<List<DepotModel>> GetAll()
		{
			return (await _repository.GetDepots()).Select(DepotModel.Create).ToList();
		}

		[HttpGet("{gid}")]
		public async Task<DepotModel> GetDepot(Guid gid)
		{
			return DepotModel.Create(await _repository.GetDepot(gid));
		}

		[HttpPost]
		public async Task<DepotModel> PostAsync([FromBody] DepotDto depotDto)
		{
			var depot = new Depot
			{
				AreaId = depotDto.AreaId,
				DepotName = depotDto.DepotName,
				Shape = GeometryHelper.CreatePoint(depotDto.Shape)
			};

			return DepotModel.Create(await _repository.AddDepot(depot));
		}

		[HttpPut]
		public async Task<DepotModel> PutAsync([FromBody] DepotDto depotDto)
		{
			var depot = await _repository.GetDepot(depotDto.Gid);

			depot.AreaId = depotDto.AreaId;
			depot.DepotName = depotDto.DepotName;
			depot.Shape = GeometryHelper.CreatePoint(depotDto.Shape);

			return DepotModel.Create(await _repository.AddDepot(depot));
		}

		[HttpDelete("{gid}")]
		public async Task DeleteAsync(Guid gid)
		{
			await _repository.DeleteDepot(gid);
		}
	}
}
