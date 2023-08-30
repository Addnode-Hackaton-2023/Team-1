namespace Allwin_Planning.Core.Entities
{
    public class Vehicles
    {
        public Guid Gid { get; set; }
        public string VehicleName { get; set; }
        public int Capacity { get; set; }
        public Guid DepotId { get; set; }
    }
}
