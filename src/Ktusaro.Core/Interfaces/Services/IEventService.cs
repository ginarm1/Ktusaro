using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAll();
        Task<List<Event>> Filter(int id, string? eventType);
        Task<List<Event>> GetByEventType(string eventType);
    }
}
