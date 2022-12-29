using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<User> GetByEmail(string email);
        public Task ChangeRoleByEmail(string email, int roleValue);
        public Task ChangeRepresentativeByEmail(string email, int representativeValue);
        public Task<int> Create(User user);
    }
}
