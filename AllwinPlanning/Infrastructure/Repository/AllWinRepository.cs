﻿using AllwinPlanning.Core.Entities;
using AllwinPlanning.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AllwinPlanning.Infrastructure.Repository
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

		public async Task<Depot> GetDepot(Guid areaId)
		{
			return await m_Context.Depots.FirstOrDefaultAsync(d => d.AreaId == areaId) ?? throw new Exception("Not found");
		}

		public async Task<Pickup> GetPickup(Guid gid)
		{
			return await m_Context.Pickups.FirstOrDefaultAsync(d => d.Gid == gid) ?? throw new Exception("Not found");
		}

		public async Task<Delivery> GetDelivery(Guid gid)
		{
			return await m_Context.Deliveries.Include(d => d.DeliveryDays).FirstOrDefaultAsync(d => d.Gid == gid) ?? throw new Exception("Not found");
		}

		public Task<Depot> AddDepot(Depot depot)
		{
			var result = m_Context.Add(depot);
			return Task.FromResult(result.Entity);
		}

		public Task<Pickup> AddPickup(Pickup pickup)
		{
			var result = m_Context.Add(pickup);
			return Task.FromResult(result.Entity);
		}

		public Task<Delivery> AddDelivery(Delivery delivery)
		{
			var result = m_Context.Add(delivery);
			return Task.FromResult(result.Entity);
		}

		public async Task DeleteDepot(Guid gid)
		{
			var depot = await m_Context.Depots.FirstOrDefaultAsync(d => d.Gid == gid) ?? throw new Exception("Not found");
			m_Context.Depots.Remove(depot);
		}

		public async Task DeletePickup(Guid gid)
		{
			var pickup = await m_Context.Pickups.FirstOrDefaultAsync(d => d.Gid == gid) ?? throw new Exception("Not found");
			m_Context.Pickups.Remove(pickup);
		}

		public async Task DeleteDelivery(Guid gid)
		{
			var delivery = await m_Context.Deliveries.FirstOrDefaultAsync(d => d.Gid == gid) ?? throw new Exception("Not found");
			m_Context.Deliveries.Remove(delivery);
		}
	}
}