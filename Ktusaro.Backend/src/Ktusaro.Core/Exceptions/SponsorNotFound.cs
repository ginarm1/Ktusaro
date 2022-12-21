namespace Ktusaro.Core.Exceptions
{
    public class SponsorNotFound : EntityNotFoundException
    {
        public SponsorNotFound() : base("notFound","Sponsor was not found")
        { 
        }
    }
}
