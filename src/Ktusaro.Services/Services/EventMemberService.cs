using Ktusaro.Core.Exceptions;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Core.Models;

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

        public async Task<EventMember> Create(EventMember eventMember)
        {
            var @event = await _eventRepository.GetById(eventMember.EventId);

            if (@event == null)
            {
                throw new EventNotFound();
            }

            var user = await _userRepository.GetById(eventMember.UserId);

            if (user == null)
            {
                throw new UserNotFound();
            }

            var eventsMembers = await _eventMemberRepository.GetAll();

            if (eventsMembers.Where(em => user.Id == em.UserId && @event.Id == em.EventId).FirstOrDefault() != null)
            {
                throw new EventMemberAlreadyExists();
            }

            if (eventsMembers.Where(em => @event.Id == em.EventId && em.IsEventCoordinator && eventMember.IsEventCoordinator).FirstOrDefault() != null)
            {
                throw new EventCoordinatorAlreadyExists();
            }

            var insertedEventMemberId = await _eventMemberRepository.Create(eventMember);
            var insertedEventMember = await _eventMemberRepository.GetById(insertedEventMemberId);

            return insertedEventMember;
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

        public async Task<EventMember> Update(int id, bool isEventCoordinator)
        {
            var eventsMembers = await _eventMemberRepository.GetAll();

            if (await _eventMemberRepository.GetById(id) == null)
            {
                throw new EventMemberNotFound();
            }

            var eventMember = await _eventMemberRepository.GetById(id);

            if (isEventCoordinator)
            {
                var eventCoordinatorsCount = eventsMembers.Where(em => em.EventId == eventMember.EventId && em.IsEventCoordinator).ToList().Count;

                if (eventCoordinatorsCount > 0)
                {
                    throw new EventCoordinatorAlreadyExists();
                }
            }

            eventMember.IsEventCoordinator = isEventCoordinator;

            var updatedSponsorshipId = await _eventMemberRepository.Update(id, eventMember);
            var updatedSponsorship = await _eventMemberRepository.GetById(updatedSponsorshipId);

            return updatedSponsorship;
        }
    }
}
