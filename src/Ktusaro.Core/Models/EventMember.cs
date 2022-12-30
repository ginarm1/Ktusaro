namespace Ktusaro.Core.Models
{
    public class EventMember
    {
        public int Id { get; set; }
        public bool IsEventCoordinator { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
