using AutoMapper;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Core.Models;
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

        [HttpPost("eventsmembers")]
        public async Task<IActionResult> CreateEventMember(CreateEventMemberRequest request)
        {
            var eventMember = _mapper.Map<EventMember>(request);

            var insertedEventMember = await _eventMemberService.Create(eventMember);
            var insertedEventMemberResponse = _mapper.Map<EventMemberResponse>(insertedEventMember);

            return CreatedAtAction(nameof(GetEventMemberById), new { id = insertedEventMemberResponse.Id }, insertedEventMemberResponse);
        }

        [HttpGet("eventsmembers")]
        public async Task<IActionResult> GetAllEventsMembers([FromQuery] EventMemberFilterParameters parameters)
        {
            var eventsMembers = await _eventMemberService.GetAll(parameters?.IsEventCoordinator,parameters.EventId, parameters.UserId);
            return Ok(_mapper.Map<List<EventMemberResponse>>(eventsMembers));
        }

        [HttpGet("eventsmembers/{id}")]
        public async Task<IActionResult> GetEventMemberById(int id)
        {
            var eventMember = await _eventMemberService.GetById(id);

            return Ok(eventMember);
        }
    }
}
