using AutoFixture.NUnit3;
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
    public class SponsorshipServiceTests
    {
        private Mock<ISponsorshipRepository> _sponsorshipRepositoryMock;
        private Mock<ISponsorRepository> _sponsorRepositoryMock;
        private Mock<IEventRepository> _eventRepositoryMock;
        private SponsorshipService _sponsorshipService;

        [SetUp]
        public void Setup()
        {
            _sponsorshipRepositoryMock = new Mock<ISponsorshipRepository>();
            _sponsorRepositoryMock = new Mock<ISponsorRepository>();
            _eventRepositoryMock = new Mock<IEventRepository>();
            _sponsorshipService = new SponsorshipService(_sponsorshipRepositoryMock.Object, _sponsorRepositoryMock.Object, _eventRepositoryMock.Object);
        }

        [Test, AutoData]
        public async Task Create_ValidSponsorshipData_CreatesSponsorship(Sponsorship sponsorship)
        {
            _sponsorRepositoryMock.Setup(x => x.GetById(sponsorship.SponsorId)).ReturnsAsync(new Sponsor());
            _eventRepositoryMock.Setup(x => x.GetById(sponsorship.EventId)).ReturnsAsync(new Event());

            _sponsorshipRepositoryMock.Setup(x => x.Create(sponsorship)).ReturnsAsync(sponsorship.Id);
            _sponsorshipRepositoryMock.Setup(x => x.GetById(sponsorship.Id)).ReturnsAsync(new Sponsorship
            {
                Id = sponsorship.Id
            });

            var result = await _sponsorshipService.Create(sponsorship);

            _sponsorshipRepositoryMock.Verify(x => x.Create(It.IsAny<Sponsorship>()), Times.Once);
            _sponsorshipRepositoryMock.Verify(x => x.GetById(sponsorship.Id), Times.Once);
            Assert.That(result.Id, Is.EqualTo(sponsorship.Id));
        }

        [Test, AutoData]
        public void Create_SponsorIdNotFound_ThrowsException(Sponsorship sponsorship)
        {
            _sponsorRepositoryMock.Setup(x => x.GetById(sponsorship.SponsorId)).ReturnsAsync(value: null);

            Assert.That(async () => await _sponsorshipService.Create(sponsorship),
                Throws.Exception.TypeOf<SponsorNotFound>().With.Message.EqualTo("Sponsor was not found"));

            _sponsorRepositoryMock.Verify(x => x.Create(It.IsAny<Sponsor>()), Times.Never);
        }

        [Test, AutoData]
        public void Create_EventIdNotFound_ThrowsException(Sponsorship sponsorship)
        {
            _sponsorRepositoryMock.Setup(x => x.GetById(sponsorship.SponsorId)).ReturnsAsync(new Sponsor());
            _eventRepositoryMock.Setup(x => x.GetById(sponsorship.EventId)).ReturnsAsync(value: null);

            Assert.That(async () => await _sponsorshipService.Create(sponsorship),
                Throws.Exception.TypeOf<EventNotFound>().With.Message.EqualTo("Event was not found"));

            _eventRepositoryMock.Verify(x => x.Create(It.IsAny<Event>()), Times.Never);
        }

        [Test]
        public async Task GetAll_NoInput_ReturnsAllSponsorships()
        {
            var allSponsorships = new List<Sponsorship>
            {
                new Sponsorship
                {
                    Id = 1,
                    Description = "Dvi dėžės",
                    Quantity = 2,
                    Cost = 10.99m,
                    SponsorId = 1,
                    EventId = 2
                },
                new Sponsorship
                {
                    Id = 2,
                    Description = "Keturios paletės po tris dėžes",
                    Quantity = 4,
                    Cost = 20.99m,
                    SponsorId = 2,
                    EventId = 2
                },

            };

            _sponsorshipRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allSponsorships);

            var result = await _sponsorshipService.GetAll(0,0);

            Assert.That(result, Has.Count.EqualTo(allSponsorships.Count));
        }

        [Test]
        public async Task GetAll_BothParametersAreZero_ReturnsAllSponsorships()
        {
            var allSponsorships = new List<Sponsorship>
            {
                new Sponsorship
                {
                    Id = 1,
                    Description = "Dvi dėžės",
                    Quantity = 2,
                    Cost = 10.99m,
                    SponsorId = 1,
                    EventId = 2
                },
                new Sponsorship
                {
                    Id = 2,
                    Description = "Keturios paletės po tris dėžes",
                    Quantity = 4,
                    Cost = 20.99m,
                    SponsorId = 2,
                    EventId = 2
                },

            };

            _sponsorshipRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allSponsorships);

            var result = await _sponsorshipService.GetAll(0, 0);

            Assert.That(result, Has.Count.EqualTo(allSponsorships.Count));
        }

        [Test]
        public async Task GetAll_SponsorParametersIsZerpAndEventParameterIsNotZero_ReturnsSponsorshipsThatMatchSponsorId()
        {
            var validResultSponsorshipsCount = 2;

            _eventRepositoryMock.Setup(x => x.GetById(2)).ReturnsAsync(new Event());

            var allSponsorships = new List<Sponsorship>
            {
                new Sponsorship
                {
                    Id = 1,
                    Description = "Dvi dėžės",
                    Quantity = 2,
                    Cost = 10.99m,
                    SponsorId = 1,
                    EventId = 2
                },
                new Sponsorship
                {
                    Id = 2,
                    Description = "Keturios paletės po tris dėžes",
                    Quantity = 4,
                    Cost = 20.99m,
                    SponsorId = 2,
                    EventId = 2
                },

            };

            _sponsorshipRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allSponsorships);

            var result = await _sponsorshipService.GetAll(0, 2);

            Assert.That(result, Has.Count.EqualTo(validResultSponsorshipsCount));
        }

        [Test]
        [TestCase(2)]
        public async Task Update_ValidSponsorshipData_UpdatesSponsorship(int sponsorshipId)
        {
            var allSponsorships = new List<Sponsorship>
            {
                new Sponsorship
                {
                    Id = 1,
                    Description = "Dvi dėžės",
                    Quantity = 2,
                    Cost = 10.99m,
                    SponsorId = 1,
                    EventId = 2
                },
                new Sponsorship
                {
                    Id = 2,
                    Description = "Keturios paletės po tris dėžes",
                    Quantity = 4,
                    Cost = 20.99m,
                    SponsorId = 2,
                    EventId = 2
                },

            };

            var newSponsorship = new Sponsorship
            {
                Id = 2,
                Description = "Šešios paletės po tris dėžes",
                Quantity = 6,
                Cost = 50.99m,
                SponsorId = 2,
                EventId = 2
            };

            _sponsorshipRepositoryMock.Setup(x => x.Update(sponsorshipId, newSponsorship)).ReturnsAsync(sponsorshipId);
            _sponsorshipRepositoryMock.Setup(x => x.GetById(sponsorshipId)).ReturnsAsync(new Sponsorship
            {
                Id = sponsorshipId
            });

            var result = await _sponsorshipService.Update(sponsorshipId, newSponsorship);

            _sponsorshipRepositoryMock.Verify(x => x.Update(sponsorshipId, It.IsAny<Sponsorship>()), Times.Once);
            _sponsorshipRepositoryMock.Verify(x => x.GetById(sponsorshipId), Times.AtLeastOnce);
            Assert.That(result.Id, Is.EqualTo(sponsorshipId));
        }

        [Test, AutoData]
        public void Update_SponsorshipIdNotFound_ThrowsException(Sponsorship sponsorship)
        {
            _sponsorshipRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(value: null);

            Assert.That(async () => await _sponsorshipService.Update(It.IsAny<int>(), sponsorship),
                Throws.Exception.TypeOf<SponsorshipNotFound>());

            _sponsorshipRepositoryMock.Verify(x => x.Update(It.IsAny<int>(), sponsorship), Times.Never);
        }

        [Test]
        public void GetById_SponsorshipIdNotFound_ThrowsException()
        {
            _sponsorshipRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(value: null);

            Assert.That(async () => await _sponsorshipService.GetById(It.IsAny<int>()),
                Throws.Exception.TypeOf<SponsorshipNotFound>());
        }

        [Test]
        [TestCase(2)]
        public async Task Delete_ValidSponsorshipId_DeletesSponsorship(int sponsorship)
        {
            _sponsorshipRepositoryMock.Setup(x => x.GetById(sponsorship)).ReturnsAsync(new Sponsorship
            {
                Id = sponsorship
            });

            var result = await _sponsorshipService.Delete(sponsorship);

            _sponsorshipRepositoryMock.Verify(x => x.Delete(sponsorship), Times.Once);
            _sponsorshipRepositoryMock.Verify(x => x.GetById(sponsorship), Times.Once);
        }

        [Test]
        public void Delete_SponsorshipIdNotFound_ThrowsException()
        {
            _sponsorshipRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(value: null);

            Assert.That(async () => await _sponsorshipService.Delete(It.IsAny<int>()),
                Throws.Exception.TypeOf<SponsorshipNotFound>());

            _sponsorshipRepositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}
