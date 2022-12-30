using AutoFixture.NUnit3;
using Ktusaro.Core.Exceptions;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Models;
using Ktusaro.Services.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ktusaro.UnitTests
{
    public class EventServiceTests
    {
        private Mock<IEventRepository> _eventRepositoryMock;
        private EventService _eventService;

        [SetUp]
        public void Setup()
        {
            _eventRepositoryMock= new Mock<IEventRepository>();
            _eventService = new EventService(_eventRepositoryMock.Object);
        }

        [Test, AutoData]
        public async Task Create_ValidEventData_CreatesEvent(Event @event)
        {
            _eventRepositoryMock.Setup(x => x.Create(@event)).ReturnsAsync(@event.Id);
            _eventRepositoryMock.Setup(x => x.GetById(@event.Id)).ReturnsAsync(new Event
            {
                Id = @event.Id
            });

            var result = await _eventService.Create(@event);

            _eventRepositoryMock.Verify(x => x.Create(It.IsAny<Event>()), Times.Once);
            _eventRepositoryMock.Verify(x => x.GetById(@event.Id), Times.Once);
            Assert.That(result.Id, Is.EqualTo(@event.Id));
        }

        [Test]
        public async Task GetAll_BothFilterParametersAreNull_ReturnsAllEvents()
        {
            var allEvents = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Name = "GrandŽIK",
                    StartDate = System.DateTime.Today,
                    EndDate = System.DateTime.Today,
                    Location = "Kaunas",
                    Description= "Žmogiškųjų išteklių komandos renginys",
                    CoordinatorName= "Gintaras",
                    CoordinatorSurname= "Armonaitis",
                    IsCanceled= false,
                    IsLive= true,
                    PlannedPeopleCount= 50,
                    ShowedPeopleCount = 45,
                    EventType = EventType.Vidinis
                },
                new Event
                {
                    Id = 2,
                    Name = "Laisvėje gime",
                    StartDate = System.DateTime.Today,
                    EndDate = System.DateTime.Today,
                    Location = "Vilnius",
                    Description= "Renginys, skirtas paminėti Sausio 13-tą",
                    CoordinatorName= "Darius",
                    CoordinatorSurname= "Daraitis",
                    IsCanceled= false,
                    IsLive= false,
                    PlannedPeopleCount= 50,
                    ShowedPeopleCount = 0,
                    EventType = EventType.Masinis
                },
            };

            _eventRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEvents);

            var result = await _eventService.GetAll(0, null);

            Assert.That(result, Has.Count.EqualTo(allEvents.Count));
        }

        [Test]
        public async Task GetAll_EventTypeParameterIsNullAndIdParameterIsValid_ReturnsEventsThatMatchId()
        {
            var validEventId = 2;
            var validEventsCount = 1;

            _eventRepositoryMock.Setup(x => x.GetById(validEventId)).ReturnsAsync(new Event());

            var allEvents = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Name = "GrandŽIK",
                    StartDate = System.DateTime.Today,
                    EndDate = System.DateTime.Today,
                    Location = "Kaunas",
                    Description= "Žmogiškųjų išteklių komandos renginys",
                    CoordinatorName= "Gintaras",
                    CoordinatorSurname= "Armonaitis",
                    IsCanceled= false,
                    IsLive= true,
                    PlannedPeopleCount= 50,
                    ShowedPeopleCount = 45,
                    EventType = EventType.Vidinis
                },
                new Event
                {
                    Id = 2,
                    Name = "Laisvėje gime",
                    StartDate = System.DateTime.Today,
                    EndDate = System.DateTime.Today,
                    Location = "Vilnius",
                    Description= "Renginys, skirtas paminėti Sausio 13-tą",
                    CoordinatorName= "Darius",
                    CoordinatorSurname= "Daraitis",
                    IsCanceled= false,
                    IsLive= false,
                    PlannedPeopleCount= 50,
                    ShowedPeopleCount = 0,
                    EventType = EventType.Masinis
                },
            };

            _eventRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEvents);

            var result = await _eventService.GetAll(validEventId, null);

            Assert.That(result, Has.Count.EqualTo(validEventsCount));
            Assert.That(result.Single().Id, Is.EqualTo(validEventId));
        }

        [Test]
        public void GetAll_EventTypeParameterIsValidAndIdParameterIsInvalid_ThrowsException()
        {
            var invalidEventId = 10;

            _eventRepositoryMock.Setup(x => x.GetById(invalidEventId)).ReturnsAsync(value: null);

            var allEvents = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Name = "GrandŽIK",
                    StartDate = System.DateTime.Today,
                    EndDate = System.DateTime.Today,
                    Location = "Kaunas",
                    Description= "Žmogiškųjų išteklių komandos renginys",
                    CoordinatorName= "Gintaras",
                    CoordinatorSurname= "Armonaitis",
                    IsCanceled= false,
                    IsLive= true,
                    PlannedPeopleCount= 50,
                    ShowedPeopleCount = 45,
                    EventType = EventType.Vidinis
                },
                new Event
                {
                    Id = 2,
                    Name = "Laisvėje gime",
                    StartDate = System.DateTime.Today,
                    EndDate = System.DateTime.Today,
                    Location = "Vilnius",
                    Description= "Renginys, skirtas paminėti Sausio 13-tą",
                    CoordinatorName= "Darius",
                    CoordinatorSurname= "Daraitis",
                    IsCanceled= false,
                    IsLive= false,
                    PlannedPeopleCount= 50,
                    ShowedPeopleCount = 0,
                    EventType = EventType.Masinis
                },
            };

            _eventRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEvents);

            Assert.That(async () => await _eventService.GetAll(invalidEventId, "Masinis"),
                Throws.Exception.TypeOf<EventNotFound>().With.Message.EqualTo("Event was not found"));
        }

        [Test]
        public void GetAll_EventTypeParameterIsInvalidAndIdParameterIsValid_ThrowsException()
        {
            var invalidEventId = 10;

            _eventRepositoryMock.Setup(x => x.GetById(invalidEventId)).ReturnsAsync(value: null);

            var allEvents = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Name = "GrandŽIK",
                    StartDate = System.DateTime.Today,
                    EndDate = System.DateTime.Today,
                    Location = "Kaunas",
                    Description= "Žmogiškųjų išteklių komandos renginys",
                    CoordinatorName= "Gintaras",
                    CoordinatorSurname= "Armonaitis",
                    IsCanceled= false,
                    IsLive= true,
                    PlannedPeopleCount= 50,
                    ShowedPeopleCount = 45,
                    EventType = EventType.Vidinis
                },
                new Event
                {
                    Id = 2,
                    Name = "Laisvėje gime",
                    StartDate = System.DateTime.Today,
                    EndDate = System.DateTime.Today,
                    Location = "Vilnius",
                    Description= "Renginys, skirtas paminėti Sausio 13-tą",
                    CoordinatorName= "Darius",
                    CoordinatorSurname= "Daraitis",
                    IsCanceled= false,
                    IsLive= false,
                    PlannedPeopleCount= 50,
                    ShowedPeopleCount = 0,
                    EventType = EventType.Masinis
                },
            };

            _eventRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allEvents);

            Assert.That(async () => await _eventService.GetAll(invalidEventId, "Random"),
                Throws.Exception.TypeOf<EventTypeNotFound>().With.Message.EqualTo("Event type was not found"));
        }

        [Test]
        public void GetById_EventIdNotFound_ThrowsException()
        {
            _eventRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(value: null);

            Assert.That(async () => await _eventService.GetById(It.IsAny<int>()),
                Throws.Exception.TypeOf<EventNotFound>());
        }

        [Test]
        [TestCase(2)]
        public async Task Update_ValidEventData_UpdatesEvent(int eventId)
        {
            var allEvents = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Name = "GrandŽIK",
                    StartDate = System.DateTime.Today,
                    EndDate = System.DateTime.Today,
                    Location = "Kaunas",
                    Description= "Žmogiškųjų išteklių komandos renginys",
                    CoordinatorName= "Gintaras",
                    CoordinatorSurname= "Armonaitis",
                    IsCanceled= false,
                    IsLive= true,
                    PlannedPeopleCount= 50,
                    ShowedPeopleCount = 45,
                    EventType = EventType.Vidinis
                },
                new Event
                {
                    Id = 2,
                    Name = "Laisvėje gime",
                    StartDate = System.DateTime.Today,
                    EndDate = System.DateTime.Today,
                    Location = "Vilnius",
                    Description= "Renginys, skirtas paminėti Sausio 13-tą",
                    CoordinatorName= "Darius",
                    CoordinatorSurname= "Daraitis",
                    IsCanceled= false,
                    IsLive= false,
                    PlannedPeopleCount= 50,
                    ShowedPeopleCount = 0,
                    EventType = EventType.Masinis
                },
            };

            var newEvent = new Event
                {
                    Id = eventId,
                    Name = "InfoShow",
                    StartDate = System.DateTime.Today,
                    EndDate = System.DateTime.Today,
                    Location = "Vilnius",
                    Description = "Renginys, skirtas paminėti Sausio 13-tą",
                    CoordinatorName = "Darius",
                    CoordinatorSurname = "Daraitis",
                    IsCanceled = false,
                    IsLive = false,
                    PlannedPeopleCount = 50,
                    ShowedPeopleCount = 0,
                    EventType = EventType.Masinis
                };

            _eventRepositoryMock.Setup(x => x.Update(eventId,newEvent)).ReturnsAsync(eventId);
            _eventRepositoryMock.Setup(x => x.GetById(eventId)).ReturnsAsync(new Event
            {
                Id = eventId
            });

            var result = await _eventService.Update(eventId, newEvent);

            _eventRepositoryMock.Verify(x => x.Update(eventId,It.IsAny<Event>()), Times.Once);
            _eventRepositoryMock.Verify(x => x.GetById(eventId), Times.AtLeastOnce);
            Assert.That(result.Id, Is.EqualTo(eventId));
        }

        [Test,AutoData]
        public void Update_EventIdNotFound_ThrowsException(Event @event)
        {

            _eventRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(value: null);

            Assert.That(async () => await _eventService.Update(It.IsAny<int>(),@event),
                Throws.Exception.TypeOf<EventNotFound>());

            _eventRepositoryMock.Verify(x => x.Update(It.IsAny<int>(), @event), Times.Never);
        }

        [Test]
        [TestCase(2)]
        public async Task Delete_ValidEventId_DeletesEvent(int eventId)
        {
            _eventRepositoryMock.Setup(x => x.GetById(eventId)).ReturnsAsync(new Event
            {
                Id = eventId
            });

            var result = await _eventService.Delete(eventId);

            _eventRepositoryMock.Verify(x => x.Delete(eventId), Times.Once);
            _eventRepositoryMock.Verify(x => x.GetById(eventId), Times.Once);
        }

        [Test]
        public void Delete_EventIdNotFound_ThrowsException()
        {
            _eventRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(value: null);

            Assert.That(async () => await _eventService.Delete(It.IsAny<int>()),
                Throws.Exception.TypeOf<EventNotFound>());

            _eventRepositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}