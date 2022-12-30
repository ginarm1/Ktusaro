using AutoMapper;
using Ktusaro.Services.Services;
using Ktusaro.WebApp.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ktusaro.WebApp.Controllers
{
    [ApiController]
    [Route("api")]
    public class EventMembersController : ControllerBase
    {
        private readonly EventMemberService _eventMemberService;
        private readonly IMapper _mapper;

        public EventMembersController(EventMemberService eventMemberService, IMapper mapper)
        {
            _eventMemberService = eventMemberService;
            _mapper = mapper;
        }

        [HttpGet("eventsmembers")]
        public async Task<IActionResult> GetAllEventsMembers([FromQuery] EventMemberFilterParameters parameters)
        {
            var eventsMembers = await _eventMemberService.GetAll(parameters?.IsEventCoordinator,parameters.EventId, parameters.UserId);
            return Ok(_mapper.Map<List<EventMemberResponse>>(eventsMembers));
        }

        [HttpGet("eventsmembers/{id}")]
        public async Task<IActionResult> GetSponsorshipById(int id)
        {
            var eventMember = await _eventMemberService.GetById(id);

            return Ok(eventMember);
        }
    }
}
