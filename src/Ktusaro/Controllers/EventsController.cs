using AutoMapper;
using Ktusaro.Services.Services;
using Ktusaro.WebApp.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ktusaro.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(EventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var eventEntity = await _eventService.GetAll();
            return Ok(_mapper.Map<List<EventDto>>(eventEntity));
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
