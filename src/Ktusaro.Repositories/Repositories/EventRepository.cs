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

            var entities = await _connection.QueryAsync<Event>(selectQuery);
            return entities.ToList();
        }

        public async Task<List<Event>> GetByEventType(string eventType)
        {
            if (eventType == null)
            {
                throw new ArgumentNullException(nameof(eventType));
            }

            if (!Enum.IsDefined(typeof(EventType), eventType))
            {
                throw new EventTypeNotFound();
            }

            string selectQuery = "";
            int index = 0;

            for (int i = 1; i < Enum.GetNames(typeof(EventType)).Length; i++)
            {
                if (eventType == Enum.GetName(typeof(EventType), i))
                {
                    selectQuery = EventRepositoryCommands.GetByEventType();
                    index = i;
                    break;
                }
            }

            var entities = await _connection.QueryAsync<Event>(selectQuery, new { EventType = index });
            return entities.ToList();
        }
    }
}
