using DevTestBackend.Infrastructure.Persistence.Context;
using DevTestBackend.Infrastructure.Persistence.Interfaces;
using DevTestBackend.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevTestBackend.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(DbContextTestBackEnd).Assembly.FullName;

            services.AddDbContext<DbContextTestBackEnd>(x => x.UseSqlServer(configuration.GetConnectionString("DevConnectionString"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;

        }
    }
}
