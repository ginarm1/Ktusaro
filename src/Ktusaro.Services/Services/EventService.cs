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

        public async Task<List<Event>> GetAll(int id, string? eventType)
        {
            var events = await _eventRepository.GetAll();

            if (id != 0 && eventType != null)
            {
                events = await GetByEventType(eventType);
                events = events.Where(e => e.Id == id).ToList();
            }
            else if (eventType != null)
            {
                events = await GetByEventType(eventType);
            }
            else if (id != 0)
            {
                events = events.Where(e => e.Id == id).ToList();
            }
       
            return events;
        }

        public async Task<Event> GetById(int id)
        {
            var @event = await _eventRepository.GetById(id);

            if (@event == null)
            {
                throw new EventNotFound();
            }

            return @event;
        }

        public async Task<List<Event>> GetByEventType(string eventType)
        {
            if (eventType == null)
            {
                throw new ArgumentNullException(nameof(eventType));
            }

            eventType = FirstCharToUpper(eventType);

            if (!Enum.IsDefined(typeof(EventType), eventType))
            {
                throw new EventTypeNotFound();
            }

            int eventTypeValue = 0;

            for (int i = 1; i < Enum.GetNames(typeof(EventType)).Length; i++)
            {
                if (eventType == Enum.GetName(typeof(EventType), i))
                {

                    eventTypeValue = i;
                    break;
                }
            }

            var events = await _eventRepository.GetByEventType(eventTypeValue);

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
