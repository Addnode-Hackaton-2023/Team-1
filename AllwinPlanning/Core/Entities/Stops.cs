namespace AllwinPlanning.Core.Entities
{
    public class Stops
    {
        public Depot Depot { get; init; }

        public IEnumerable<Pickup> Pickups { get; init; }

        public IEnumerable<Delivery> Deliveries { get; init; }

    }
}
