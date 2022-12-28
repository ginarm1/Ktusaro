namespace Ktusaro.Core.Exceptions
{
    public class UserNotFound : EntityNotFoundException
    {
        public UserNotFound() : base("notFound", "User was not found")
        {
        }
    }
}
