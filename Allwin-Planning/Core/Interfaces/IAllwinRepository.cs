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
		Task<Depot> GetDepot(Guid gid);
		Task<Pickup> GetPickup(Guid gid);
		Task<Delivery> GetDelivery(Guid gid);
		Task<Depot> AddDepot(Depot depot);
		Task<Pickup> AddPickup(Pickup pickup);
		Task<Delivery> AddDelivery(Delivery delivery);
		Task DeleteDepot(Guid gid);
		Task DeletePickup(Guid gid);
		Task DeleteDelivery(Guid gid);
	}
}
