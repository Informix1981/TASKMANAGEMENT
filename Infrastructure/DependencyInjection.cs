using Application.Service.PersistenceDb;
using Application.Service.PersistenceDb.Interfaces;
using Infrastructure.PersistenceDb;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        // Register infrastructure-specific services here
        services.AddDbContext<AppDbContext>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}