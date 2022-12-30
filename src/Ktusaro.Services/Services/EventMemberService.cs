using Ktusaro.Core.Exceptions;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace Ktusaro.Services.Services
{
    public class EventMemberService : IEventMemberService
    {
        private readonly IEventMemberRepository _eventMemberRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;

        public EventMemberService(IEventMemberRepository eventMemberRepository, IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventMemberRepository = eventMemberRepository;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        public async Task<List<EventMember>> GetAll(bool? isEventCoordinator,int eventId, int userId)
        {
            var eventsMembers = await _eventMemberRepository.GetAll();

            if (isEventCoordinator != null)
            {
                if (isEventCoordinator == true)
                {
                    eventsMembers = eventsMembers.Where(s => s.IsEventCoordinator).ToList();
                }
                else
                {
                    eventsMembers = eventsMembers.Where(s => !s.IsEventCoordinator).ToList();
                }
            }

            if (eventId != 0)
            {
                var @event = await _eventRepository.GetById(eventId);

                if (@event == null)
                {
                    throw new EventNotFound();
                }

                eventsMembers = eventsMembers.Where(s => s.EventId == eventId).ToList();
            }

            if (userId != 0)
            {
                var user = await _userRepository.GetById(userId);

                if (user == null)
                {
                    throw new UserNotFound();
                }

                eventsMembers = eventsMembers.Where(s => s.UserId == userId).ToList();
            }

            if (isEventCoordinator != null && (eventId != 0 || userId != 0))
            {
                eventsMembers = FilterIsCoordinatorNotNull(eventsMembers, (bool)isEventCoordinator, eventId, userId);
            }

            else if (eventId != 0 && userId != 0)
            {
                eventsMembers = eventsMembers.Where(s => s.EventId == eventId && s.UserId == userId).ToList();
            }

            return eventsMembers;
        }

        public async Task<EventMember> GetById(int id)
        {
            var eventMember = await _eventMemberRepository.GetById(id);

            if (eventMember == null)
            {
                throw new EventMemberNotFound();
            }

            return eventMember;
        }

        private List<EventMember> FilterIsCoordinatorNotNull(List<EventMember> eventsMembers, bool isEventCoordinator, int eventId, int userId)
        {
            if (eventId != 0 && userId != 0)
            {
                if (isEventCoordinator == true)
                {
                    eventsMembers = eventsMembers.Where(s => s.IsEventCoordinator == true && s.EventId == eventId && s.UserId == userId).ToList();
                }
                else
                {
                    eventsMembers = eventsMembers.Where(s => s.IsEventCoordinator == false && s.EventId == eventId && s.UserId == userId).ToList();
                }
            }
            else if (eventId != 0)
            {
                if (isEventCoordinator == true)
                {
                    eventsMembers = eventsMembers.Where(s => s.IsEventCoordinator == true && s.EventId == eventId).ToList();
                }
                else
                {
                    eventsMembers = eventsMembers.Where(s => s.IsEventCoordinator == false && s.EventId == eventId).ToList();
                }
            }
            else if (userId != 0)
            {
                if (isEventCoordinator == true)
                {
                    eventsMembers = eventsMembers.Where(s => s.IsEventCoordinator == true && s.UserId == userId).ToList();
                }
                else
                {
                    eventsMembers = eventsMembers.Where(s => s.IsEventCoordinator == false && s.UserId == userId).ToList();
                }
            }

            return eventsMembers;
        }
    }
}
