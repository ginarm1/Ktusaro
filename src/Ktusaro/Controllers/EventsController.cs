﻿using AutoMapper;
using Ktusaro.Core.Models;
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

        [HttpPost("events")]
        public async Task<IActionResult> CreateKudos(CreateEventRequest request)
        {
            var @event = _mapper.Map<Event>(request);

            var insertedEvent = await _eventService.Create(@event);
            var insertedEventResponse = _mapper.Map<EventResponse>(insertedEvent);

            return CreatedAtAction(nameof(GetEventById), new { id = insertedEventResponse.Id }, insertedEventResponse);
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetAllEvents([FromQuery] EventFilterQuery eventFilterDto)
        {
            var eventsEntity = await _eventService.GetAll(eventFilterDto.Id,eventFilterDto.EventType);
            return Ok(_mapper.Map<List<EventResponse>>(eventsEntity));
        }

        //[HttpGet("events/{id}")]
        private async Task<EventResponse> GetEventById(int id)
        {
            var eventEntity = _mapper.Map <EventResponse>(await _eventService.GetById(id));

            return eventEntity;
        }
    }
}
