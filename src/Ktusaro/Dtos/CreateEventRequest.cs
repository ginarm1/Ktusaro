using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Ktusaro.Core.Models;

namespace Ktusaro.WebApp.Dtos
{
    public class CreateEventRequest
    {
        [Required(ErrorMessage = "Event name is required")]
        [MaxLength(250)]

        public string? Name { get; set; }

        [Required(ErrorMessage = "Event start date is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Event end date is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [MaxLength(100)]
        public string? Location { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CoordinatorName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CoordinatorSurname { get; set; }

        [Required]
        public bool IsCanceled { get; set; }

        [Required]
        public bool IsLive { get; set; }

        [Required]
        [Range(0, 99999)]
        [DisplayName("Planuojamas dalyvių kiekis")]
        public int? PlannedPeopleCount { get; set; }

        [Range(0, 99999)]
        [DisplayName("Pasirodžiusių dalyvių kiekis")]
        public int? ShowedPeopleCount { get; set; }

        [Required]
        public EventType EventType { get; set; }
    }
}
