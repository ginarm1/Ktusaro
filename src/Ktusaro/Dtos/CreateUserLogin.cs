using System.ComponentModel.DataAnnotations;

namespace Ktusaro.WebApp.Dtos
{
    public class CreateUserLogin
    {
        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
