using Dapper;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Models;
using Ktusaro.Repositories.SqlCommands;
using Npgsql;

namespace Ktusaro.Repositories.Repositories
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly NpgsqlConnection _connection;

        public SponsorRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Sponsor>> GetAll()
        {
            string selectQuery = SponsorsRepositoryCommands.GetAll();

            var sponsors = await _connection.QueryAsync<Sponsor>(selectQuery);
            return sponsors.ToList();
        }

        public async Task<Sponsor> GetById(int id)
        {
            string selectQuery = SponsorsRepositoryCommands.GetById();
            var sponsor = await _connection.QuerySingleOrDefaultAsync<Sponsor>(selectQuery, new { Id = id });
            return sponsor;
        }
    }
}
