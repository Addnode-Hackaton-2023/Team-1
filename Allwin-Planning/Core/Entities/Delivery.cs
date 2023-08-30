using NetTopologySuite.Geometries;

namespace Allwin_Planning.Core.Entities
{
    public class Delivery
    {
        public Guid Gid { get; set; }
        public string DeliveryName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public Point Shape { get; set; }
        public int StopTime { get; set; }
        public Guid VehicleId { get; set; }
    }
}
