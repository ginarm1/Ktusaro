namespace Ktusaro.Core.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(string reason, string message) : base(reason, message)
        {
        }
    }
}
