﻿using NetTopologySuite.Geometries;

namespace AllwinPlanning.Core.Entities
{
	public class Delivery
	{
		public Delivery()
		{
			DeliveryDays = new List<DeliveryDay>();
		}

		public Guid Gid { get; set; }
		public string DeliveryName { get; set; }
		public string ContactName { get; set; }
		public string ContactPhone { get; set; }
		public Point Shape { get; set; }
		public int StopTime { get; set; }
		public Guid VehicleId { get; set; }
		public List<DeliveryDay> DeliveryDays { get; set; }
	}
}
