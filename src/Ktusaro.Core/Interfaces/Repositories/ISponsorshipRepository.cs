using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Repositories
{
    public interface ISponsorshipRepository
    {
        public Task<List<Sponsorship>> GetAll();
    }
}
