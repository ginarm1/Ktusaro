using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Repositories
{
    public interface IEventRepository
    {
        public Task<int> Create(Event @event);
        public Task<List<Event>> GetAll();
        public Task<Event> GetById(int id);
        public Task<List<Event>> GetByEventType(int eventTypeValue);
    }
}
