using Microsoft.Extensions.DependencyInjection;
namespace Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}