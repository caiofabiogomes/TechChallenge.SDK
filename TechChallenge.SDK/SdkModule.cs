using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.SDK.Infrastructure.Persistence;

namespace TechChallenge.SDK
{
    public static class SdkModule
    {
        public static IServiceCollection RegisterSdkModule(this IServiceCollection services, string connectionString)
        {
            return services
                    .AddPersistence(connectionString)
                    .RegisterRepositories();
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
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
