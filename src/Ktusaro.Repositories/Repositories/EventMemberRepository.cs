using Dapper;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Models;
using Ktusaro.Repositories.SqlCommands;
using Npgsql;

namespace Ktusaro.Repositories.Repositories
{
    public class EventMemberRepository : IEventMemberRepository
    {
        private readonly NpgsqlConnection _connection;

        public EventMemberRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<EventMember>> GetAll()
        {
            string selectQuery = EventMemberRepositoryCommands.GetAll();

            var eventMembers = await _connection.QueryAsync<EventMember>(selectQuery);
            return eventMembers.ToList();
        }

        public async Task<EventMember> GetById(int id)
        {
            string selectQuery = EventMemberRepositoryCommands.GetById();
            var eventMemberEntity = await _connection.QuerySingleOrDefaultAsync<EventMember>(selectQuery, new { Id = id });
            return eventMemberEntity;
        }

        public async Task<int> Create(EventMember eventMember)
        {
            string insertQuery = EventMemberRepositoryCommands.Create();

            var insertedEventMemberId = await _connection.ExecuteScalarAsync<int>(insertQuery, eventMember);

            return insertedEventMemberId;
        }

        public async Task<int> Update(int id, EventMember eventMember)
        {
            string updateQuery = EventMemberRepositoryCommands.Update();

            var updatedEventMemberId = await _connection.ExecuteScalarAsync<int>(updateQuery,
                new
                {
                    Id = id,
                    eventMember.IsEventCoordinator,
                    eventMember.EventId,
                    eventMember.UserId
                });

            return updatedEventMemberId;
        }

        public async Task<int> Delete(int id)
        {
            string deleteQuery = EventMemberRepositoryCommands.Delete();

            var deletedEventMemberId = await _connection.ExecuteScalarAsync<int>(deleteQuery, new { Id = id });

            return deletedEventMemberId;
        }
    }
}
