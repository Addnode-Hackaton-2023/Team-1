using NetTopologySuite.Geometries;

namespace Allwin_Planning.Core.Entities
{
    public class Depots
    {
        public Guid Gid { get; set; }
        public string DepotName { get; set; }
        public Point Shape { get; set; }
        public Guid AreaId { get; set; }
    }
}
