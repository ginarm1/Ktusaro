namespace Ktusaro.Core.Exceptions
{
    public class EventTypeNotFound : EntityNotFoundException
    {
        public EventTypeNotFound() : base("notFound","Event type was not found")
        {
        }
    }
}
