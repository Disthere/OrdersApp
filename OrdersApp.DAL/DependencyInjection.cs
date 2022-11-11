using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.DAL.Persistence;
using System.Reflection;

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

        public static IServiceCollection AddMediatR(this IServiceCollection
            services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection
            services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
            });

            return services;
        }
    }
}
