using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Repositories
{
    public interface IEventRepository
    {
        public Task<List<Event>> GetAll();
        public Task<Event> GetById(int id);
        public Task<List<Event>> GetByEventType(int eventTypeValue);
    }
}
