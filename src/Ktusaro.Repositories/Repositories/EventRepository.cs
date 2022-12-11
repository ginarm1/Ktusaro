using Dapper;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Models;
using Ktusaro.Repositories.SqlCommands;
using Npgsql;

namespace Ktusaro.Repositories.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly NpgsqlConnection _connection;

        public EventRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Event>> GetAll()
        {
            string selectQuery = EventRepositoryCommands.GetAll();

            var entities = await _connection.QueryAsync<Event>(selectQuery);
            return entities.ToList();
        }
    }
}
