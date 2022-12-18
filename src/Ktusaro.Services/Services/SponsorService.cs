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

        public async Task<Sponsor> Create(Sponsor sponsor)
        {
            var insertedSponsorId = await _sponsorRepository.Create(sponsor);
            var insertedSponsor = await _sponsorRepository.GetById(insertedSponsorId);

            return insertedSponsor;
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

        public async Task<Sponsor> Update(int id, Sponsor sponsor)
        {
            if (await _sponsorRepository.GetById(id) == null)
            {
                throw new SponsorNotFound();
            }

            var updatedSponsorId = await _sponsorRepository.Update(id, sponsor);
            var updatedSponsor = await _sponsorRepository.GetById(updatedSponsorId);

            return updatedSponsor;
        }

        public async Task<int> Delete(int id)
        {
            if (await _sponsorRepository.GetById(id) == null)
            {
                throw new SponsorNotFound();
            }

            var deletedSponsorId = await _sponsorRepository.Delete(id);

            return deletedSponsorId;
        }
    }
}
