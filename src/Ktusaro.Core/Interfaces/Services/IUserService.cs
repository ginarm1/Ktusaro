using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<User> Register(User user, string password);
        public Task<string> Login(User request, string password);
    }
}
