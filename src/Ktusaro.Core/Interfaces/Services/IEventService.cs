using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Services
{
    public interface IEventService
    {
        public Task<Event> Create(Event @event);
        public Task<List<Event>> GetAll(int id, string? eventType);
        public Task<Event> GetById(int id);
        public Task<List<Event>> GetByEventType(string eventType);
        public Task<Event> Update(int id, Event @event);
    }
}
