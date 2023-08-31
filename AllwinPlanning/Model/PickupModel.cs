using AllwinPlanning.Core;
using AllwinPlanning.Core.Entities;
using System.Linq.Expressions;

namespace AllwinPlanning.Model
{
	public class PickupModel
	{
		public Guid Gid { get; set; }
		public string PickupName { get; set; }
		public string ContactName { get; set; }
		public string ContactPhoneNumber { get; set; }
		public int AvarageVolume { get; set; }
		public int OpeningHour { get; set; }
		public int ClosingHour { get; set; }
		public int AvarageStoptime { get; set; }
		public Guid VehicleId { get; set; }
		public EsriPointModel Shape { get; set; }
		public bool Active { get; set; } = true;
		public PickupType PickupType { get; set; }

		public static Expression<Func<Pickup, PickupModel>> Projection => (d) => new PickupModel
		{
			Gid = d.Gid,
			PickupName = d.PickupName,
			ContactName = d.ContactName,
			ContactPhoneNumber = d.ContactPhoneNumber,
			AvarageVolume = d.AvarageVolume,
			OpeningHour = d.OpeningHour,
			ClosingHour = d.ClosingHour,
			AvarageStoptime = d.AvarageStoptime,
			VehicleId = d.VehicleId,
			Active = d.Active,
			PickupType = d.PickupType,
			Shape = EsriPointModel.Create(d.Shape)
		};

		public static PickupModel Create(Pickup d) => Projection.Compile().Invoke(d);
	}
}
