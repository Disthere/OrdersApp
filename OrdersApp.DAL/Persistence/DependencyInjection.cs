using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OrdersApp.DAL.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSqliteDbConnection(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqliteDbConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetService<ApplicationDbContext>());

            return services;
        }
    }
}
