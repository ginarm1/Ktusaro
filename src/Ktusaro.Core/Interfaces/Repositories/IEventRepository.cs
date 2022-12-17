using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAll();
        Task<List<Event>> GetByEventType(int eventTypeValue);
    }
}
