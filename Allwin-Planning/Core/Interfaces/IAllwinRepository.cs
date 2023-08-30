using Allwin_Planning.Core.Entities;

namespace Allwin_Planning.Core.Interfaces
{
	public interface IAllwinRepository
	{
		Task<List<Pickup>> GetPickups(Guid vehicleId);
		Task<List<Delivery>> GetDeliveries(Guid vehicleId, int weekday);
		Task<List<Depot>> GetDepots();
		Task<List<Vehicle>> GetVehicles();
		Task<List<Area>> GetAreas();
	}
}
