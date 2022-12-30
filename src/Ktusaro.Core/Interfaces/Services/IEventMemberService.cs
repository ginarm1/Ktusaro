using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Services
{
    public interface IEventMemberService
    {
        public Task<List<EventMember>> GetAll(bool? isEventCoordinator,int eventId, int userId);
        public Task<EventMember> GetById(int id);
    }
}
