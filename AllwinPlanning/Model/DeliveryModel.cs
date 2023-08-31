using AllwinPlanning.Core.Entities;
using System.Linq.Expressions;

namespace AllwinPlanning.Model
{
	public class DeliveryModel
	{
		public Guid Gid { get; set; }
		public string DeliveryName { get; set; }
		public string ContactName { get; set; }
		public string ContactPhone { get; set; }
		public EsriPointModel Shape { get; set; }
		public int StopTime { get; set; }
		public Guid VehicleId { get; set; }
		public List<DeliveryDay> DeliveryDays { get; set; }

		public static Expression<Func<Delivery, DeliveryModel>> Projection => (d) => new DeliveryModel
		{
			Gid = d.Gid,
			DeliveryName = d.DeliveryName,
			ContactName = d.ContactName,
			ContactPhone = d.ContactPhone,
			DeliveryDays = d.DeliveryDays,
			StopTime = d.StopTime,
			VehicleId = d.VehicleId,
			Shape = EsriPointModel.Create(d.Shape)
		};

		public static DeliveryModel Create(Delivery d) => Projection.Compile().Invoke(d);
	}
}
