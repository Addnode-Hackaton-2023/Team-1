using AllwinPlanning.Core.Entities;
using System.Linq.Expressions;

namespace AllwinPlanning.Model
{
	public class DepotModel
	{
		public Guid Gid { get; set; }
		public string DepotName { get; set; }
		public EsriPointModel Shape { get; set; }
		public Guid AreaId { get; set; }

		public static Expression<Func<Depot, DepotModel>> Projection => (d) => new DepotModel
		{
			Gid = d.Gid,
			DepotName = d.DepotName,
			AreaId = d.AreaId,
			Shape = EsriPointModel.Create(d.Shape)
		};

		public static DepotModel Create(Depot d) => Projection.Compile().Invoke(d);
	}
}
