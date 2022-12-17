using Ktusaro.Core.Exceptions;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Core.Models;

namespace Ktusaro.Services.Services
{
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorRepository _sponsorRepository;

        public SponsorService(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public async Task<List<Sponsor>> GetAll()
        {
            var sponsors = await _sponsorRepository.GetAll();

            if (sponsors == null)
            {
                throw new ();
            }

            return sponsors;
        }

        public async Task<Sponsor> GetById(int id)
        {
            var sponsor = await _sponsorRepository.GetById(id);

            if (sponsor == null)
            {
                throw new SponsorNotFound();
            }

            return sponsor;
        }
    }
}
