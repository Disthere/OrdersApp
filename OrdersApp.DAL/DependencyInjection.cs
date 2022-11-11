using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersApp.DAL.Persistence;

namespace OrdersApp.DAL
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
