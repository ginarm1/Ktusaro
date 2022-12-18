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

        public async Task<int> Create(Sponsor sponsor)
        {
            string insertQuery = SponsorsRepositoryCommands.Create();

            var insertedSponsorId = await _connection.ExecuteScalarAsync<int>(insertQuery, sponsor);

            return insertedSponsorId;
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

        public async Task<int> Update(int id, Sponsor sponsor)
        {
            string updateQuery = SponsorsRepositoryCommands.Update();

            var updatedSponsorId = await _connection.ExecuteScalarAsync<int>(updateQuery,
                new
                {
                    Id = id,
                    sponsor.Name,
                    sponsor.CompanyType
                });

            return updatedSponsorId;
        }
    }
}
