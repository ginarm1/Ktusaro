using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Repositories
{
    public interface IEventMemberRepository
    {
        public Task<int> Create(EventMember eventMember);
        public Task<int> Update(int id, EventMember eventMember);
        public Task<List<EventMember>> GetAll();
        public Task<EventMember> GetById(int id);
        public Task<int> Delete(int id);
    }
}
