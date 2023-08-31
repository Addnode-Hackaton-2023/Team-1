using AllwinPlanning.Core;

namespace AllwinPlanning.Dto
{
	public class PickupDto
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
		public EsriPointDto Shape { get; set; }
		public bool Active { get; set; } = true;
		public PickupType PickupType { get; set; }
	}
}
