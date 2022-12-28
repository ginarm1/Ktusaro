namespace Ktusaro.Core.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string CoordinatorName { get; set; }
        public string CoordinatorSurname { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsLive { get; set; }
        public int PlannedPeopleCount { get; set; }
        public int ShowedPeopleCount { get; set; }
        public EventType EventType { get; set; }
    }

    public enum EventType
    {
        Vidinis = 1,
        Masinis = 2,
        Komercinis = 3,
        Fakultetinis = 4,
        Tarpastovybinis = 5
    }
}
