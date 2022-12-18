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
            string insertQuery = SponsorRepositoryCommands.Create();

            var insertedSponsorId = await _connection.ExecuteScalarAsync<int>(insertQuery, sponsor);

            return insertedSponsorId;
        }

        public async Task<List<Sponsor>> GetAll()
        {
            string selectQuery = SponsorRepositoryCommands.GetAll();

            var sponsors = await _connection.QueryAsync<Sponsor>(selectQuery);
            return sponsors.ToList();
        }

        public async Task<Sponsor> GetById(int id)
        {
            string selectQuery = SponsorRepositoryCommands.GetById();
            var sponsor = await _connection.QuerySingleOrDefaultAsync<Sponsor>(selectQuery, new { Id = id });
            return sponsor;
        }

        public async Task<int> Update(int id, Sponsor sponsor)
        {
            string updateQuery = SponsorRepositoryCommands.Update();

            var updatedSponsorId = await _connection.ExecuteScalarAsync<int>(updateQuery,
                new
                {
                    Id = id,
                    sponsor.Name,
                    sponsor.CompanyType
                });

            return updatedSponsorId;
        }

        public async Task<int> Delete(int id)
        {
            string deleteQuery = SponsorRepositoryCommands.Delete();

            var deletedSponsorId = await _connection.ExecuteScalarAsync<int>(deleteQuery, new { Id = id });

            return deletedSponsorId;
        }
    }
}
