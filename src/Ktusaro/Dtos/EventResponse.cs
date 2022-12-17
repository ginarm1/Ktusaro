namespace Ktusaro.WebApp.Dtos
{
    public class EventResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool Has_coordinator { get; set; }
        public string? CoordinatorName { get; set; }
        public string? CoordinatorSurname { get; set; }
        public bool Is_canceled { get; set; }
        public int? PlannedPeopleCount { get; set; }
        public int? ShowedPeopleCount { get; set; }
        public int? PeopleCount { get; set; }
        public string? EventType { get; set; }
    }
}
