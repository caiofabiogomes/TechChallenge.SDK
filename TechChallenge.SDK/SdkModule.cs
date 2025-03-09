using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.SDK.Persistence;

namespace TechChallenge.SDK
{
    public static class SdkModule
    {
        public static IServiceCollection AddSdkModule(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ContactsDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IContactRepository, ContactRepository>();
            return services;
        }
    }
}
