namespace Allwin_Planning.Core.Entities
{
    public class StopLog
    {
        public Guid Gid { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public string StopId { get; set; }
        public string? StopType { get; set; }
        public string? Status { get; set; }
    }
}
