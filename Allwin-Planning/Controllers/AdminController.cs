using Allwin_Planning.Core.Entities;
using Allwin_Planning.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Allwin_Planning.Controllers
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
        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _repository.GetVehicles();
        }
    }
}
