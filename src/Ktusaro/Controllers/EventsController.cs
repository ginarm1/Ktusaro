using AutoMapper;
using Ktusaro.Services.Services;
using Ktusaro.WebApp.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ktusaro.WebApp.Controllers
{
    [ApiController]
    [Route("api")]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(EventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetAllEvents([FromQuery] EventFilterQuery eventFilterDto)
        {
            var eventsEntity = await _eventService.GetAll(eventFilterDto.Id,eventFilterDto.EventType);
            return Ok(_mapper.Map<List<EventResponse>>(eventsEntity));
        }

        [HttpGet("events/{id}")]
        public async Task<IActionResult> GetEventsById(int id)
        {
            var eventEntity = await _eventService.GetById(id);

            return Ok(eventEntity);
        }
    }
}
