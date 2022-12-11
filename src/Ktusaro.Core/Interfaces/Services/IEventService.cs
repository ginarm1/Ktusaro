using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAll();
    }
}
