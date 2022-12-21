using Ktusaro.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Ktusaro.WebApp.Dtos
{
    public class CreateSponsorRequest
    {
        [Required(ErrorMessage = "Sponsor name is required")]
        [MaxLength(250)]

        public string? Name { get; set; }
        [Required(ErrorMessage = "Sponsor company type is required")]

        public CompanyType CompanyType { get; set; }
    }
}
