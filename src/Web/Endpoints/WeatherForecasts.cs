using MyAwesomeDotnetDockerApp.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace MyAwesomeDotnetDockerApp.Web.Endpoints;

public static class WeatherForecasts
{
    public static RouteGroupBuilder MapWeatherForecasts(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/weatherforecasts");
        group.WithTags("WeatherForecasts");
        group
            .RequireAuthorization()
            .MapGet("/", async (ISender sender) => await sender.Send(new GetWeatherForecastsQuery()));
        
        return group;
    }
}