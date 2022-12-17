using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Repositories
{
    public interface ISponsorRepository
    {
        public Task<List<Sponsor>> GetAll();
        public Task<Sponsor> GetById(int id);
    }
}
