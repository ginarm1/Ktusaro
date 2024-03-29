﻿using Ktusaro.Core.Models;

namespace Ktusaro.Core.Interfaces.Services
{
    public interface IEventMemberService
    {
        public Task<List<EventMember>> GetAll(bool? isEventCoordinator,int eventId, int userId);
        public Task<EventMember> GetById(int id);
        public Task<EventMember> Create(EventMember eventMember);
        public Task<EventMember> Update(int id, bool isEventCoordinator);
        public Task<int> Delete(int id);
    }
}
