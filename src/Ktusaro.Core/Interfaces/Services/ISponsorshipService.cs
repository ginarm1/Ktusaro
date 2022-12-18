using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Services
{
    public interface ISponsorshipService
    {
        public Task<List<Sponsorship>> GetAll();
    }
}
