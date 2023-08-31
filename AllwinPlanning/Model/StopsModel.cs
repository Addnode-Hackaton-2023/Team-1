namespace AllwinPlanning.Model
{
	public class StopsModel
	{
		public DepotModel Depot { get; init; }

		public IEnumerable<PickupModel> Pickups { get; init; }

		public IEnumerable<DeliveryModel> Deliveries { get; init; }

	}
}
