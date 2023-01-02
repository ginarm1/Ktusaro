namespace Ktusaro.Core.Exceptions
{
    public class EventMemberAlreadyExists : ValidationException
    {
        public EventMemberAlreadyExists() : base("conflict", "Event member already exists")
        {
        }
    }
}
