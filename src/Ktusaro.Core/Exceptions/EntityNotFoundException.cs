namespace Ktusaro.Core.Exceptions
{
    public class EntityNotFoundException : BaseException
    {
        public EntityNotFoundException(string reason, string message) : base(reason,message)
        {
        }
    }
}
