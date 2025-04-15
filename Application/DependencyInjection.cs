using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}