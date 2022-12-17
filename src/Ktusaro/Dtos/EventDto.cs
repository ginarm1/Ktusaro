﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ktusaro.WebApp.Dtos
{
    public class EventDto
    {
        [Key]
        [Required]
        public int? Id { get; set; }

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
        public bool Has_coordinator { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CoordinatorName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CoordinatorSurname { get; set; }

        [Required]
        public bool Is_canceled { get; set; }

        [Required]
        public bool Is_live { get; set; }

        [Required]
        [Range(0, 99999)]
        [DisplayName("Planuojamas dalyvių kiekis")]
        public int? PlannedPeopleCount { get; set; }

        [DisplayName("Atvykusių dalyvių kiekis")]
        public int? PeopleCount { get; set; }
    }
}
