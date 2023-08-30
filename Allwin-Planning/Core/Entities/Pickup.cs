using NetTopologySuite.Geometries;

namespace Allwin_Planning.Core.Entities
{
	public class Pickup
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
		public Point Shape { get; set; }
		public bool Active { get; set; } = true;
		public PickupType PickupType { get; set; }
	}
}
