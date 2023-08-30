namespace Allwin_Planning.Core.Entities
{
    public class Vehicle
    {
        public Guid Gid { get; set; }
        public string VehicleName { get; set; }
        public int Capacity { get; set; }
        public Guid DepotId { get; set; }
        public List<Pickup> Pickups { get; set; }
        public List<Delivery> Deliveries { get; set; }
    }
}
