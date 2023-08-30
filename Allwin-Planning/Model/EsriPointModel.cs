using System.Linq.Expressions;
using Point = NetTopologySuite.Geometries.Point;

namespace Allwin_Planning.Model
{
	public class EsriPointModel
	{
		public EsriSpatialReferenceModel SpatialReference { get; set; }
		public double X { get; set; }
		public double Y { get; set; }

		public static Expression<Func<Point, EsriSpatialReferenceModel, EsriPointModel>> Projection => (p, sr) => new EsriPointModel
		{
			SpatialReference = sr,
			X = p.X,
			Y = p.Y
		};

		public static EsriPointModel Create(Point p) => Projection.Compile().Invoke(p, new EsriSpatialReferenceModel { Wkid = p.SRID });
	}
}
