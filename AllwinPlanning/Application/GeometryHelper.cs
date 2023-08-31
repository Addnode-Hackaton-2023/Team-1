using AllwinPlanning.Dto;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace AllwinPlanning.Application
{
	public static class GeometryHelper
	{
		public static Point CreatePoint(EsriPointDto point)
		{
			var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(point.SpatialReference.Wkid);
			return geometryFactory.CreatePoint(new Coordinate(point.X, point.Y));
		}
	}
}
