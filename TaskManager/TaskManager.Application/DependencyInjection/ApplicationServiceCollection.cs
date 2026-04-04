using TaskManager.Application.Services;
using TaskManager.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Interfaces.Services;
using TaskManager.Application.Interfaces.Repositories;

namespace TaskManager.Application.DependencyInjection;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        RegisterServices(services);

        return services;
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ITasksRepository, TasksRepository>();
        services.AddScoped<ITasksServices, TasksServices>();
    }
}