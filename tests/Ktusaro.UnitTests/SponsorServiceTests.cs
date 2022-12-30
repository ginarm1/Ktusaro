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
    public class SponsorServiceTests
    {
        private Mock<ISponsorRepository> _sponsorRepositoryMock;
        private SponsorService _sponsorService;

        [SetUp]
        public void Setup()
        {
            _sponsorRepositoryMock = new Mock<ISponsorRepository>();
            _sponsorService = new SponsorService(_sponsorRepositoryMock.Object);
        }

        [Test, AutoData]
        public async Task Create_ValidSponsorData_CreatesSponsor(Sponsor sponsor)
        {
            _sponsorRepositoryMock.Setup(x => x.Create(sponsor)).ReturnsAsync(sponsor.Id);
            _sponsorRepositoryMock.Setup(x => x.GetById(sponsor.Id)).ReturnsAsync(new Sponsor
            {
                Id = sponsor.Id
            });

            var result = await _sponsorService.Create(sponsor);

            _sponsorRepositoryMock.Verify(x => x.Create(It.IsAny<Sponsor>()), Times.Once);
            _sponsorRepositoryMock.Verify(x => x.GetById(sponsor.Id), Times.Once);
            Assert.That(result.Id, Is.EqualTo(sponsor.Id));
        }

        [Test]
        public async Task GetAll_NoInput_ReturnsAllSponsors()
        {
            var allSponsors = new List<Sponsor>
            {
                new Sponsor
                {
                    Id = 1,
                    Name = "Green Bull",
                    CompanyType = CompanyType.UAB
                },
                new Sponsor
                {
                    Id = 2,
                    Name = "Vilniaus grūdai",
                    CompanyType = CompanyType.AB
                },
            };

            _sponsorRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(allSponsors);

            var result = await _sponsorService.GetAll();

            Assert.That(result, Has.Count.EqualTo(allSponsors.Count));
        }

        [Test]
        [TestCase(2)]
        public async Task Update_ValidSponsorData_UpdatesSponsor(int sponsorId)
        {
            var allSponsors = new List<Sponsor>
            {
                new Sponsor
                {
                    Id = 1,
                    Name = "Green Bull",
                    CompanyType = CompanyType.UAB
                },
                new Sponsor
                {
                    Id = 2,
                    Name = "Vilniaus grūdai",
                    CompanyType = CompanyType.AB
                },
            };

            var newSponsor = new Sponsor
            {
                Id = 2,
                Name = "Saulės pasaulis",
                CompanyType = CompanyType.UAB
            };

            _sponsorRepositoryMock.Setup(x => x.Update(sponsorId, newSponsor)).ReturnsAsync(sponsorId);
            _sponsorRepositoryMock.Setup(x => x.GetById(sponsorId)).ReturnsAsync(new Sponsor
            {
                Id = sponsorId
            });

            var result = await _sponsorService.Update(sponsorId, newSponsor);

            _sponsorRepositoryMock.Verify(x => x.Update(sponsorId, It.IsAny<Sponsor>()), Times.Once);
            _sponsorRepositoryMock.Verify(x => x.GetById(sponsorId), Times.AtLeastOnce);
            Assert.That(result.Id, Is.EqualTo(sponsorId));
        }

        [Test,AutoData]
        public void Update_SponsorIdNotFound_ThrowsException(Sponsor sponsor)
        {
            _sponsorRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(value: null);

            Assert.That(async () => await _sponsorService.Update(It.IsAny<int>(), sponsor),
                Throws.Exception.TypeOf<SponsorNotFound>());

            _sponsorRepositoryMock.Verify(x => x.Update(It.IsAny<int>(), sponsor), Times.Never);
        }

        [Test]
        public void GetById_SponsorIdNotFound_ThrowsException()
        {
            _sponsorRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(value: null);

            Assert.That(async () => await _sponsorService.GetById(It.IsAny<int>()),
                Throws.Exception.TypeOf<SponsorNotFound>());
        }

        [Test]
        [TestCase(2)]
        public async Task Delete_ValidSponsorId_DeletesSponsor(int sponsorId)
        {
            _sponsorRepositoryMock.Setup(x => x.GetById(sponsorId)).ReturnsAsync(new Sponsor
            {
                Id = sponsorId
            });

            var result = await _sponsorService.Delete(sponsorId);

            _sponsorRepositoryMock.Verify(x => x.Delete(sponsorId), Times.Once);
            _sponsorRepositoryMock.Verify(x => x.GetById(sponsorId), Times.Once);
        }

        [Test]
        public void Delete_SponsorIdNotFound_ThrowsException()
        {
            _sponsorRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(value: null);

            Assert.That(async () => await _sponsorService.Delete(It.IsAny<int>()),
                Throws.Exception.TypeOf<SponsorNotFound>());

            _sponsorRepositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}
