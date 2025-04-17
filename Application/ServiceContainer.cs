using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Service.PersistenceDb.Implementation;
using Application.Service.PersistenceDb.Interfaces;
using Application.Validators;
using FluentValidation;
namespace Application;
public static class ServiceContainer
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserGroupService, UserGroupService>();
        services.AddScoped<IAssignmentService,AssignmentService>();

        services.AddValidatorsFromAssemblyContaining<UserValidator>();
        services.AddValidatorsFromAssemblyContaining<UserGroupValidator>();
        services.AddValidatorsFromAssemblyContaining<AssignmentValidator>();
        return services;
    }
}