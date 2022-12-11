using Ktusaro.Core.Exceptions;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Core.Models;

namespace Ktusaro.Services.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public async Task<List<Event>> GetAll()
        {
            var events = await _eventRepository.GetAll();

            if (events == null)
            {
                throw new EventNotFound();
            }

            return events;
        }
    }
}
