using AllwinPlanning.Core.Entities;
using System.Linq.Expressions;

namespace AllwinPlanning.Model
{
	public class VehicleModel
	{
		public Guid Gid { get; set; }
		public string VehicleName { get; set; }
		public int Capacity { get; set; }
		public Guid DepotId { get; set; }
		public List<PickupModel> Pickups { get; set; }
		public List<DeliveryModel> Deliveries { get; set; }

		public static Expression<Func<Vehicle, VehicleModel>> Projection => (v) => new VehicleModel
		{
			Gid = v.Gid,
			VehicleName = v.VehicleName,
			Capacity = v.Capacity,
			DepotId = v.DepotId,
			Pickups = v.Pickups.Select(PickupModel.Create).ToList(),
			Deliveries = v.Deliveries.Select(DeliveryModel.Create).ToList()
		};

		public static VehicleModel Create(Vehicle d) => Projection.Compile().Invoke(d);
	}
}
