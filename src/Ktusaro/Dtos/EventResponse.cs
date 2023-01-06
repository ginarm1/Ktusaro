namespace Ktusaro.WebApp.Dtos
{
    public class EventResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? CoordinatorName { get; set; }
        public string? CoordinatorSurname { get; set; }
        public bool IsCanceled { get; set; }
        public int? PlannedPeopleCount { get; set; }
        public int? ShowedPeopleCount { get; set; }
        public string? EventType { get; set; }
    }
}
