namespace Ktusaro.Core.Exceptions
{
    public class EventMemberNotFound : EntityNotFoundException
    {
        public EventMemberNotFound() : base("notFound", "Event member was not found")
        {
        }
    }
}
