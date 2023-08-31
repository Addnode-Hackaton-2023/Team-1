namespace AllwinPlanning.Dto
{
	public class EsriPointDto
	{
		public SpatialReferenceDto SpatialReference { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		public double? Z { get; set; }
	}
}
