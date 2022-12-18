using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Repositories
{
    public interface ISponsorshipRepository
    {
        public Task<List<Sponsorship>> GetAll();
        public Task<Sponsorship> GetById(int id);
        public Task<int> Create(Sponsorship sponsorship);
        public Task<int> Update(int id, Sponsorship sponsorship);
    }
}
