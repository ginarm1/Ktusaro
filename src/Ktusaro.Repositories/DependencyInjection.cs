using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Repositories.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
namespace Ktusaro.Repositories
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            var connectionString = configuration.GetConnectionString("Default");

            services.AddTransient((sp) => new NpgsqlConnection(connectionString));

            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ISponsorRepository, SponsorRepository>();
            services.AddTransient<ISponsorshipRepository, SponsorshipRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEventMemberRepository, EventMemberRepository>();
        }
    }
}
