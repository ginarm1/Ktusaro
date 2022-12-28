using Dapper;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Models;
using Ktusaro.Repositories.SqlCommands;
using Npgsql;

namespace Ktusaro.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NpgsqlConnection _connection;

        public UserRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(User user)
        {
            string insertQuery = UserRepositoryCommands.Create();

            var insertedUserId = await _connection.ExecuteScalarAsync<int>(insertQuery, user);

            return insertedUserId;
        }

        public async Task<List<User>> GetAll()
        {
            string selectQuery = UserRepositoryCommands.GetAll();

            var users = await _connection.QueryAsync<User>(selectQuery);
            return users.ToList();
        }

        public async Task<User> GetById(int id)
        {
            string selectQuery = UserRepositoryCommands.GetById();
            var user = await _connection.QuerySingleOrDefaultAsync<User>(selectQuery, new { Id = id });
            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            string selectQuery = UserRepositoryCommands.GetByEmail();
            var user = await _connection.QuerySingleOrDefaultAsync<User>(selectQuery, new { Email = email });
            return user;
        }
    }
}
