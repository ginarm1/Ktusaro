using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Repositories
{
    public interface ISponsorRepository
    {
        public Task<int> Create(Sponsor sponsor);
        public Task<List<Sponsor>> GetAll();
        public Task<Sponsor> GetById(int id);
        public Task<int> Update(int id, Sponsor sponsor);
    }
}
