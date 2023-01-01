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

            var insertedSponsorshipId = await _connection.ExecuteScalarAsync<int>(insertQuery, eventMember);

            return insertedSponsorshipId;
        }
    }
}
