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
        public async Task<IActionResult> GetAllEvents([FromQuery] EventFilterDto eventFilterDto)
        {
            var eventEntity = await _eventService.Filter(eventFilterDto.Id,eventFilterDto.EventType);
            return Ok(_mapper.Map<List<CreateEventDto>>(eventEntity));
        }

        //public EventsController(EventService eventService)
        //{
        //    _eventService = eventService;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
