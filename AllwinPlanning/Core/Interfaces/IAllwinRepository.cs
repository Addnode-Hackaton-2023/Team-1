using AllwinPlanning.Core.Entities;

namespace AllwinPlanning.Core.Interfaces
{
	public interface IAllwinRepository
	{
		Task<List<Pickup>> GetPickups(Guid vehicleId);
		Task<List<Pickup>> GetAllPickups();
		Task<List<Delivery>> GetDeliveries(Guid vehicleId, int weekday);
		Task<List<Delivery>> GetAllDeliveries();
		Task<List<Depot>> GetDepots();
		Task<List<Vehicle>> GetVehicles();
		Task<List<Area>> GetAreas();
		Task<Depot> GetDepot(Guid gid);
		Task<Pickup> GetPickup(Guid gid);
		Task<Delivery> GetDelivery(Guid gid);
		Task<Depot> AddDepot(Depot depot);
		Task<Pickup> AddPickup(Pickup pickup);
		Task<Delivery> AddDelivery(Delivery delivery);
		Task<StopLog> AddStopLog(StopLog stopLog);
		Task<List<StopLog>> GetStopLog();
		Task DeleteDepot(Guid gid);
		Task DeletePickup(Guid gid);
		Task DeleteDelivery(Guid gid);
		void Save();
	}
}
