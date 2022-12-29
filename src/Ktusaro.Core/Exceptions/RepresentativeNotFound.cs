namespace Ktusaro.Core.Exceptions
{
    public class RepresentativeNotFound : EntityNotFoundException
    {
        public RepresentativeNotFound() : base("notFound", "Representative was not found")
        {
        }
    }
}
