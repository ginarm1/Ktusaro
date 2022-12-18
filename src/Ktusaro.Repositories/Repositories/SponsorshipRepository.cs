using Dapper;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Models;
using Ktusaro.Repositories.SqlCommands;
using Npgsql;

namespace Ktusaro.Repositories.Repositories
{
    public class SponsorshipRepository : ISponsorshipRepository
    {
        private readonly NpgsqlConnection _connection;

        public SponsorshipRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Sponsorship>> GetAll()
        {
            string selectQuery = SponsorshipRepositoryCommands.GetAll();

            var sponsorships = await _connection.QueryAsync<Sponsorship>(selectQuery);
            return sponsorships.ToList();
        }
    }
}
