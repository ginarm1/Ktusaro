namespace Ktusaro.Core.Exceptions
{
    public class EventNotFound : EntityNotFoundException
    {
        public EventNotFound() : base("notFound","Event was not found")
        {
        }
    }
}
