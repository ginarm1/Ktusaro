using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Services
{
    public interface ISponsorshipService
    {
        public Task<List<Sponsorship>> GetAll(int sponsorId, int eventId);
        public Task<Sponsorship> GetById(int id);
        public Task<Sponsorship> Create(Sponsorship sponsorship);
        public Task<Sponsorship> Update(int id, Sponsorship sponsorship);
        public Task<int> Delete(int id);
    }
}
