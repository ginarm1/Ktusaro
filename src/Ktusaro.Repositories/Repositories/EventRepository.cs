using Dapper;
using Ktusaro.Core.Exceptions;
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

            var events = await _connection.QueryAsync<Event>(selectQuery);
            return events.ToList();
        }

        public async Task<Event> GetById(int id)
        {
            string selectQuery = EventRepositoryCommands.GetById();
            var eventEntity = await _connection.QuerySingleOrDefaultAsync<Event>(selectQuery, new { Id = id });
            return eventEntity;
        }

        public async Task<List<Event>> GetByEventType(int eventTypeValue)
        {
            string selectQuery = EventRepositoryCommands.GetByEventType();
            var entities = await _connection.QueryAsync<Event>(selectQuery, new { EventType = eventTypeValue });
            return entities.ToList();
        }
    }
}
