namespace Ktusaro.Core.Exceptions
{
    public class UserEmailFormatInvalid : ValidationException
    {
        public UserEmailFormatInvalid() : base("invalid", "User email format is invalid")
        {
        }
    }
}
