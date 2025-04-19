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
        // Add database context
        services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("TaskManagementDb"));

        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
    }
}