using Allwin_Planning.Core.Entities;
using Allwin_Planning.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Allwin_Planning.Infrastructure.Repository
{
	public class AllWinRepository : IAllwinRepository
	{
		readonly AllwinContext m_Context;

		public AllWinRepository(AllwinContext context)
		{
			m_Context = context;
		}

		public async Task<List<Pickup>> GetPickups(Guid vehicleId)
		{
			return await m_Context.Pickups
				.Where(d => d.VehicleId == vehicleId)
				.ToListAsync();
		}

		public async Task<List<Delivery>> GetDeliveries(Guid vehicleId, int weekday)
		{
			return await m_Context.Deliveries
				.Include(d => d.DeliveryDays)
				.Where(d => d.VehicleId == vehicleId && d.DeliveryDays.Any(dd => dd.Weekday == weekday))
				.ToListAsync();
		}

		public async Task<List<Depot>> GetDepots()
		{
			return await m_Context.Depots.ToListAsync();
		}

		public async Task<List<Vehicle>> GetVehicles()
		{
			return await m_Context.Vehicles.ToListAsync();
		}

		public async Task<List<Area>> GetAreas()
		{
			return await m_Context.Areas.ToListAsync();
		}
	}
}
