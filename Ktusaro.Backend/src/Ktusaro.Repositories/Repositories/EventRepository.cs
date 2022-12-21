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

        public async Task<int> Create(Event @event)
        {
            string insertQuery = EventRepositoryCommands.Create();

            var insertedEventId = await _connection.ExecuteScalarAsync<int>(insertQuery, @event);

            return insertedEventId;
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

        public async Task<int> Update(int id,Event @event)
        {
            string updateQuery = EventRepositoryCommands.Update();

            var updatedEventId = await _connection.ExecuteScalarAsync<int>(updateQuery,
                new 
                {   Id = id,
                    @event.Name,
                    @event.StartDate,
                    @event.EndDate,
                    @event.Location,
                    @event.Description,
                    @event.CoordinatorName,
                    @event.CoordinatorSurname,
                    @event.IsCanceled,
                    @event.IsLive,
                    @event.PlannedPeopleCount,
                    @event.ShowedPeopleCount,
                    @event.EventType
                });

            return updatedEventId;
        }

        public async Task<int> Delete(int id)
        {
            string deleteQuery = EventRepositoryCommands.Delete();

            var deletedEventId = await _connection.ExecuteScalarAsync<int>(deleteQuery, new { Id = id });

            return deletedEventId;
        }
    }
}
