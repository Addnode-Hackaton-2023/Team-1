namespace AllwinPlanning.Dto
{
	public class DepotDto
	{
		public Guid Gid { get; set; }
		public string DepotName { get; set; }
		public EsriPointDto Shape { get; set; }
		public Guid AreaId { get; set; }
	}
}
