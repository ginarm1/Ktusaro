namespace Ktusaro.Core.Exceptions
{
    public class SponsorshipNotFound : EntityNotFoundException
    {
        public SponsorshipNotFound() : base("notFound", "Sponsorship was not found")
        {
        }
    }
}
