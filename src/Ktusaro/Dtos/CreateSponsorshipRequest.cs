using System.ComponentModel.DataAnnotations;

namespace Ktusaro.WebApp.Dtos
{
    public class CreateSponsorshipRequest
    {
        [Required(ErrorMessage = "Sponsorship descritpion name is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Sponsorship quantity is required")]
        [Range(1,99999)]
        public int Quantity { get; set; }
        [Range(1, 999999)]
        [Required(ErrorMessage = "Sponsorship cost is required")]
        public decimal Cost { get; set; }
        public int SponsorId { get; set; }
        public int EventId { get; set; }
    }
}
