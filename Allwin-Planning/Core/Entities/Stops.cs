namespace Allwin_Planning.Core.Entities
{
    public class Stops
    {
        public Depot Depot { get; init; }

        public IEnumerable<Pickup> Pickups { get; init; }

        public Delivery Delivery { get; init; }

    }
}
