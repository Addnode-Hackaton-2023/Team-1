using Allwin_Planning.Dto;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace Allwin_Planning.Application
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
