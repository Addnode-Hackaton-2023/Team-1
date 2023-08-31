using NetTopologySuite.Geometries;

namespace AllwinPlanning.Core.Entities
{
    public class Depot
    {
        public Guid Gid { get; set; }
        public string DepotName { get; set; }
        public Point Shape { get; set; }
        public Guid AreaId { get; set; }
    }
}
