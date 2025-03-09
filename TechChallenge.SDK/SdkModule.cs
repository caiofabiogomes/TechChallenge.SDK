using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.SDK.Persistence;

namespace TechChallenge.SDK
{
    public static class SdkModule
    {
        public static IServiceCollection RegisterSdkModule(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                    .AddPersistence(configuration)
                    .RegisterRepositories();
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ContactsDBContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
            return services;
        }
    }
}
