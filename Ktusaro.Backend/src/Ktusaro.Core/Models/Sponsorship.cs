namespace Ktusaro.Core.Models
{
    public class Sponsorship
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public int SponsorId { get; set; }
        public int EventId { get; set; }
    }
}
