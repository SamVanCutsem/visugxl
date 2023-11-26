using MyAwesomeDotnetDockerApp.Application.Common.Interfaces;
using MyAwesomeDotnetDockerApp.Infrastructure.Data;
using MyAwesomeDotnetDockerApp.Web.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();
        
        services.AddScoped<IUser, CurrentUser>();
        
        services.AddHttpContextAccessor();
        
        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();
        
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddSwaggerGen();
        
        services.AddEndpointsApiExplorer();

        return services;
    }
}
