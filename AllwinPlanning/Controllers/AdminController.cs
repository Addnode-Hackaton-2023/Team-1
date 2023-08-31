using AllwinPlanning.Core.Entities;
using AllwinPlanning.Core.Interfaces;
using AllwinPlanning.Model;
using Microsoft.AspNetCore.Mvc;

namespace AllwinPlanning.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class AdminController : Controller
	{
		private readonly ILogger<AdminController> _logger;
		private readonly IAllwinRepository _repository;
		public AdminController(ILogger<AdminController> logger, IAllwinRepository repository)
		{
			_logger = logger;
			_repository = repository;
		}

		[HttpGet(Name = "GetVehicles")]
		public async Task<List<VehicleModel>> GetVehicles()
		{
			return (await _repository.GetVehicles()).Select(VehicleModel.Create).ToList();
		}

        [HttpGet(Name = "GetAreas")]
        public async Task<List<Area>> GetAreas()
        {
            return await _repository.GetAreas();
        }
    }
}
