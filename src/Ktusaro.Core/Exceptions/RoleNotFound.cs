namespace Ktusaro.Core.Exceptions
{
    public class RoleNotFound : EntityNotFoundException
    {
        public RoleNotFound() : base("notFound", "Role was not found")
        {
        }
    }
}
