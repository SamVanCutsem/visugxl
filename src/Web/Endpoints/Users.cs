using MyAwesomeDotnetDockerApp.Infrastructure.Identity;

namespace MyAwesomeDotnetDockerApp.Web.Endpoints;

public static class Users
{
    public static RouteGroupBuilder MapUsers(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/users");
        group.WithTags("Users");
        group.MapIdentityApi<ApplicationUser>();
        
        return group;
    }
}
