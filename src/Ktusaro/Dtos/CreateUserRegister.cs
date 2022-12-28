using Ktusaro.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Ktusaro.WebApp.Dtos
{
    public class CreateUserRegister
    {
        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Surname { get; set; }
        public Representative Representative { get; set; }
    }
}
