using System.ComponentModel.Design;
using Application.Service.PersistenceDb;
using Application.Service.PersistenceDb.Interfaces;
using Infrastructure.PersistenceDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure;

public static class ServiceContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        // Register infrastructure-specific services here
         services.AddDbContext<AppDbContext>(option => option.UseSqlServer(config.GetConnectionString("Default"),
            sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName);
                sqlOptions.EnableRetryOnFailure();
            }),
            ServiceLifetime.Scoped);
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}