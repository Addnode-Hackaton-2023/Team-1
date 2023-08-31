using AllwinPlanning.Core.Entities;

namespace AllwinPlanning.Dto
{
	public class DeliveryDto
	{
		public DeliveryDto()
		{
			DeliveryDays = new List<DeliveryDay>();
		}

		public Guid Gid { get; set; }
		public string DeliveryName { get; set; }
		public string ContactName { get; set; }
		public string ContactPhone { get; set; }
		public EsriPointDto Shape { get; set; }
		public int StopTime { get; set; }
		public Guid VehicleId { get; set; }
		public List<DeliveryDay> DeliveryDays { get; set; }
	}
}
