using Ktusaro.Repositories;
using Ktusaro.Services.Services;

namespace Ktusaro.WebApp
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddTransient<EventService>();
            services.AddTransient<SponsorService>();
        }
    }
}
