using Allwin_Planning.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Allwin_Planning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        public Stops GetStops(Guid vehicleId, int dayOfWeek)
        {
            return new Stops()
            {
                Depot = new Depot(),
                Pickups = new List<Pickup>(),
                Delivery = new Delivery()
            };
        }
    }
}
