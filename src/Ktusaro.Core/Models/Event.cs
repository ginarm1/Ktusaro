using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ktusaro.Core.Models
{
    public class Event
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool? Has_coordinator { get; set; }
        public string? CoordinatorName { get; set; }
        public string? CoordinatorSurname { get; set; }
        public bool? Is_canceled { get; set; }
        public bool? Is_live { get; set; }
        public int? PlannedPeopleCount { get; set; }
    }
}
