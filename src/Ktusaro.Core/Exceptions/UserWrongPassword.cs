namespace Ktusaro.Core.Exceptions
{
    public class UserWrongPassword : ValidationException
    {
        public UserWrongPassword() : base("unauthorized", "Wrong password")
        {
        }
    }
}
