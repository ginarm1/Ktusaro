namespace Ktusaro.Core.Exceptions
{
    public class EventCoordinatorAlreadyExists : EntityNotFoundException
    {
        public EventCoordinatorAlreadyExists() : base("conflict", "Event coordinator already exists")
        {
        }
    }
}
