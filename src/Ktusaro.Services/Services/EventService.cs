using Ktusaro.Core.Exceptions;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Core.Models;

namespace Ktusaro.Services.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<Event>> GetAll()
        {
            var events = await _eventRepository.GetAll();

            if (events == null)
            {
                throw new EventNotFound();
            }

            return events;
        }

        public async Task<List<Event>> GetByEventType(string eventType)
        {
            eventType = FirstCharToUpper(eventType);

            var events = await _eventRepository.GetByEventType(eventType);

            if (events == null)
            {
                throw new EventNotFound();
            }

            return events;
        }

        private string FirstCharToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return $"{char.ToUpper(input[0])}{input[1..]}";
        }
    }
}
