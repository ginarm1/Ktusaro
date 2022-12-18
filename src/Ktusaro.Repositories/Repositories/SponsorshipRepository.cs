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

        public async Task<Sponsorship> GetById(int id)
        {
            string selectQuery = SponsorshipRepositoryCommands.GetById();
            var sponsorship = await _connection.QuerySingleOrDefaultAsync<Sponsorship>(selectQuery, new { Id = id });
            return sponsorship;
        }

        public async Task<int> Create(Sponsorship sponsorship)
        {
            string insertQuery = SponsorshipRepositoryCommands.Create();

            var insertedSponsorshipId = await _connection.ExecuteScalarAsync<int>(insertQuery, sponsorship);

            return insertedSponsorshipId;
        }

        public async Task<int> Update(int id, Sponsorship sponsorship)
        {
            string updateQuery = SponsorshipRepositoryCommands.Update();

            var updatedSponsorshipId = await _connection.ExecuteScalarAsync<int>(updateQuery,
                new
                {
                    Id = id,
                    sponsorship.Description,
                    sponsorship.Quantity,
                    sponsorship.Cost
                });

            return updatedSponsorshipId;
        }
    }
}
