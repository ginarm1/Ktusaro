using Ktusaro.Core.Exceptions;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Core.Models;

namespace Ktusaro.Services.Services
{
    public class SponsorshipService : ISponsorshipService
    {
        private readonly ISponsorshipRepository _sponsorshipRepository;

        public SponsorshipService(ISponsorshipRepository sponsorshipRepository)
        {
            _sponsorshipRepository = sponsorshipRepository;
        }

        public async Task<List<Sponsorship>> GetAll()
        {
            var sponsorships = await _sponsorshipRepository.GetAll();

            if (sponsorships == null)
            {
                throw new SponsorshipNotFound();
            }

            return sponsorships;
        }
    }
}
