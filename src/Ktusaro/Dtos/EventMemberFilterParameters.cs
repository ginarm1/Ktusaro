namespace Ktusaro.WebApp.Dtos
{
    public class EventMemberFilterParameters
    {
        public bool? IsEventCoordinator { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
