using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Repositories
{
    public interface IEventMemberRepository
    {
        public Task<int> Create(EventMember eventMember);
        public Task<List<EventMember>> GetAll();
        public Task<EventMember> GetById(int id);
    }
}
