namespace Ktusaro.Core.Exceptions
{
    public class BaseException : Exception
    {
        public string Reason { get; set; }

        public BaseException(string reason, string message) : base(message)
        {
            Reason = reason;
        }
    }
}
