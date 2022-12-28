namespace Ktusaro.Core.Exceptions
{
    public class UserAlreadyExists : ValidationException
    {
        public UserAlreadyExists() : base("conflict", "User with this email already exists")
        {
        }
    }
}
