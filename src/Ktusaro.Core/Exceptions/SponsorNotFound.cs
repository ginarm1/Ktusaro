namespace Ktusaro.Core.Exceptions
{
    public class SponsorNotFound : EntityNotFoundException
    {
        public SponsorNotFound() : base("notFound","Sponsor not found")
        { 
        }
    }
}
