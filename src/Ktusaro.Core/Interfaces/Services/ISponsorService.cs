using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Services
{
    public interface ISponsorService
    {
        public Task<Sponsor> Create(Sponsor sponsor);
        public Task<List<Sponsor>> GetAll();
        public Task<Sponsor> GetById(int id);
    }
}
