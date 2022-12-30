using Ktusaro.Core.Exceptions;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Models;
using Ktusaro.Services.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ktusaro.UnitTests
{
    public class EventMemberServiceTests
    {
        private Mock<IEventMemberRepository> _eventMemberRepositoryMock;
        private Mock<IEventRepository> _eventRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private EventMemberService _eventMemberService;

        [SetUp]
        public void Setup()
        {
            _eventMemberRepositoryMock = new Mock<IEventMemberRepository>();
            _eventRepositoryMock = new Mock<IEventRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _eventMemberService = new EventMemberService(_eventMemberRepositoryMock.Object,_eventRepositoryMock.Object,_userRepositoryMock.Object);
        }

        [Test]
        public async Task GetAll_NoInput_ReturnsAllEventsMembers()
        {
            var allEventsMembers = new List<EventMember>
            {
                new EventMember
                {
                    Id = 1,
                    IsEventCoordinator = false,
                    EventId = 1,
                    UserId = 1,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 1,
                    UserId = 2,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 2,
                    UserId = 3,
                },
            };

            _eventMemberRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEventsMembers);

            var result = await _eventMemberService.GetAll(null,0,0);

            Assert.That(result, Has.Count.EqualTo(allEventsMembers.Count));
        }

        [Test]
        public async Task GetAll_IsEventCoordinatorTrueAndOtherParametersZero_ReturnsEventsMembersThatAreCoordinators()
        {
            var validResultEventsMembersCount = 2;

            var allEventsMembers = new List<EventMember>
            {
                new EventMember
                {
                    Id = 1,
                    IsEventCoordinator = false,
                    EventId = 1,
                    UserId = 1,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 1,
                    UserId = 2,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 2,
                    UserId = 3,
                },
            };

            _eventMemberRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEventsMembers);

            var result = await _eventMemberService.GetAll(true, 0, 0);

            Assert.That(result, Has.Count.EqualTo(validResultEventsMembersCount));
        }

        [Test]
        public async Task GetAll_IsEventCoordinatorFalseAndOtherParametersZero_ReturnsEventsMembersThatAreNotCoordinators()
        {
            var validResultEventsMembersCount = 1;

            var allEventsMembers = new List<EventMember>
            {
                new EventMember
                {
                    Id = 1,
                    IsEventCoordinator = false,
                    EventId = 1,
                    UserId = 1,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 1,
                    UserId = 2,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 2,
                    UserId = 3,
                },
            };

            _eventMemberRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEventsMembers);

            var result = await _eventMemberService.GetAll(false, 0, 0);

            Assert.That(result, Has.Count.EqualTo(validResultEventsMembersCount));
        }

        [Test]
        public async Task GetAll_IsEventCoordinatorNullAndValidEventIdAndUserIdIsZero_ReturnsEventsMembersThatBelongsToEvent()
        {
            var validResultEventsMembersCount = 2;

            _eventRepositoryMock.Setup(x => x.GetById(1)).ReturnsAsync(new Event());

            var allEventsMembers = new List<EventMember>
            {
                new EventMember
                {
                    Id = 1,
                    IsEventCoordinator = false,
                    EventId = 1,
                    UserId = 1,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 1,
                    UserId = 2,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 2,
                    UserId = 3,
                },
            };

            _eventMemberRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEventsMembers);

            var result = await _eventMemberService.GetAll(null, 1, 0);

            Assert.That(result, Has.Count.EqualTo(validResultEventsMembersCount));
        }

        [Test]
        public async Task GetAll_IsEventCoordinatorNullAndEventIdIsZeroAndValidUserId_ReturnsEventsMembersThatBelongsToUser()
        {
            var validResultEventsMembersCount = 2;

            _userRepositoryMock.Setup(x => x.GetById(3)).ReturnsAsync(new User());

            var allEventsMembers = new List<EventMember>
            {
                new EventMember
                {
                    Id = 1,
                    IsEventCoordinator = false,
                    EventId = 1,
                    UserId = 1,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 1,
                    UserId = 2,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 2,
                    UserId = 3,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 3,
                    UserId = 3,
                },
            };

            _eventMemberRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEventsMembers);

            var result = await _eventMemberService.GetAll(null, 0, 3);

            Assert.That(result, Has.Count.EqualTo(validResultEventsMembersCount));
        }

        [Test]
        public async Task GetAll_IsEventCoordinatorTrueAndValidEventIdAndUserIdIsZero_ReturnsEventsMemberThatIsCoordinatorOfSpecificEvent()
        {
            var validResultEventsMembersCount = 1;

            _eventRepositoryMock.Setup(x => x.GetById(3)).ReturnsAsync(new Event());

            var allEventsMembers = new List<EventMember>
            {
                new EventMember
                {
                    Id = 1,
                    IsEventCoordinator = false,
                    EventId = 1,
                    UserId = 1,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 1,
                    UserId = 2,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 2,
                    UserId = 3,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 3,
                    UserId = 3,
                },
            };

            _eventMemberRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEventsMembers);

            var result = await _eventMemberService.GetAll(true, 3, 0);

            Assert.That(result, Has.Count.EqualTo(validResultEventsMembersCount));
        }

        [Test]
        public async Task GetAll_IsEventCoordinatorTrueAndEventIdIsZeroAndValidUserId_ReturnsEventsMemberThatIsCoordinatorOfSpecificUser()
        {
            var validResultEventsMembersCount = 1;

            _userRepositoryMock.Setup(x => x.GetById(2)).ReturnsAsync(new User());

            var allEventsMembers = new List<EventMember>
            {
                new EventMember
                {
                    Id = 1,
                    IsEventCoordinator = false,
                    EventId = 1,
                    UserId = 1,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 1,
                    UserId = 2,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 2,
                    UserId = 3,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 3,
                    UserId = 3,
                },
            };

            _eventMemberRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEventsMembers);

            var result = await _eventMemberService.GetAll(true, 0, 2);

            Assert.That(result, Has.Count.EqualTo(validResultEventsMembersCount));
        }

        [Test]
        public async Task GetAll_IsEventCoordinatorTrueAndValidEventIdAndValidUserId_ReturnsEventsMemberThatIsCoordinatorOfSpecificEventAndUser()
        {
            var validResultEventsMembersCount = 1;

            _eventRepositoryMock.Setup(x => x.GetById(1)).ReturnsAsync(new Event());
            _userRepositoryMock.Setup(x => x.GetById(2)).ReturnsAsync(new User());

            var allEventsMembers = new List<EventMember>
            {
                new EventMember
                {
                    Id = 1,
                    IsEventCoordinator = false,
                    EventId = 1,
                    UserId = 1,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 1,
                    UserId = 2,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 2,
                    UserId = 3,
                },
                new EventMember
                {
                    Id = 2,
                    IsEventCoordinator = true,
                    EventId = 3,
                    UserId = 3,
                },
            };

            _eventMemberRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEventsMembers);

            var result = await _eventMemberService.GetAll(true, 1, 2);

            Assert.That(result, Has.Count.EqualTo(validResultEventsMembersCount));
        }

        [Test]
        public void GetById_EventMemberIdNotFound_ThrowsException()
        {
            _eventMemberRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(value: null);

            Assert.That(async () => await _eventMemberService.GetById(It.IsAny<int>()),
                Throws.Exception.TypeOf<EventMemberNotFound>());
        }
    }
}
