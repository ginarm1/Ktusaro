using Dapper;
using Ktusaro.Core.Exceptions;
using Ktusaro.Core.Models;
using Ktusaro.Repositories.Repositories;
using Ktusaro.Services.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Ktusaro.IntegrationTests
{
    public class SponsorsController : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly SponsorRepository _sponsorRepository;
        private readonly SponsorService _sponsorService;
        private readonly NpgsqlConnection _connection;

        public SponsorsController(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            var configuration = factory.Services.GetRequiredService<IConfiguration>();

            _connection = new NpgsqlConnection(configuration.GetConnectionString("Default"));
            _sponsorRepository = new SponsorRepository(_connection);
            _sponsorService = new SponsorService(_sponsorRepository);
        }

        [Fact]
        public async Task Update_ValidSponsorData_UpdatesSponsor()
        {
            var sponsorId = 2;

            var staticSponsors = GetStaticSponsors();

            var oldSponsor = new Sponsor
            {
                Name = "Vilniaus grūdai",
                CompanyType = CompanyType.AB
            };

            var newSponsor = new Sponsor
            {
                Name = "Saulės pasaulis",
                CompanyType = CompanyType.UAB
            };

            var sponsor = staticSponsors.Single(s => s.Id == sponsorId);

            sponsor.Name = newSponsor.Name;
            sponsor.CompanyType= newSponsor.CompanyType;

            await Update(newSponsor,sponsorId);

            List<Sponsor> sponsors = new()
            {
                await _sponsorRepository.GetById(1),
                await _sponsorRepository.GetById(2)
            };

            Assert.Equal(sponsors.ToString(), staticSponsors.ToString());

            await Update(oldSponsor, sponsorId);
        }

        private async Task Update(Sponsor sponsor, int? id)
        {
            string updateQuery = @"UPDATE public.sponsor 
	                                 SET name=@Name,company_type=@CompanyType
                                     WHERE id=@Id
                                     RETURNING id";

            await _connection.ExecuteAsync(updateQuery, new
            {
                Id = id,
                sponsor.Name,
                sponsor.CompanyType
            });
        }

        [Fact]
        public async Task GetByIdSponsor_NotFoundWrongIdCode_RetrunNotFoundStatusCode()
        {
            var client = _factory.CreateDefaultClient();
            int sponsorId = -1;

            var responce = await client.GetAsync($"api/sponsors/{sponsorId}");

            Assert.Equal(HttpStatusCode.NotFound, responce.StatusCode);
        }

        [Fact]
        public async Task GetAllSponsors_NoInput_ReturnAllSponsors()
        {
            var staticSponsors = GetStaticSponsors();

            List<Sponsor> sponsors = new()
            {
                await _sponsorRepository.GetById(1),
                await _sponsorRepository.GetById(2)
            };

            Assert.Equal(staticSponsors.ToString(), sponsors.ToString());
        }

        private List<Sponsor> GetStaticSponsors()
        {
            var staticSponsors = new List<Sponsor>()
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
                }
            };

            return staticSponsors;
        }
    }
}
