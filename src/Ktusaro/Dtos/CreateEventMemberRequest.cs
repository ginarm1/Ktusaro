using Microsoft.Build.Framework;

namespace Ktusaro.WebApp.Dtos
{
    public class CreateEventMemberRequest
    {
        [Required]
        public bool? IsEventCoordinator { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
