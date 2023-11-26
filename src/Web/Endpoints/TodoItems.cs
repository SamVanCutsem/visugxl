using MyAwesomeDotnetDockerApp.Application.TodoItems.Commands.CreateTodoItem;
using MyAwesomeDotnetDockerApp.Application.TodoItems.Commands.DeleteTodoItem;
using MyAwesomeDotnetDockerApp.Application.TodoItems.Commands.UpdateTodoItem;
using MyAwesomeDotnetDockerApp.Application.TodoItems.Commands.UpdateTodoItemDetail;
using MyAwesomeDotnetDockerApp.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace MyAwesomeDotnetDockerApp.Web.Endpoints;

public static class TodoItems
{
    public static RouteGroupBuilder MapTodoItems(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/TodoItems");
        group.WithTags("TodoItems");
        group.RequireAuthorization();
        group.MapGet("/", async (ISender sender, [AsParameters] GetTodoItemsWithPaginationQuery query) => await sender.Send(query));
        group.MapPost("/", async (ISender sender, CreateTodoItemCommand command) => await sender.Send(command));
        group.MapPut("{id}", async (ISender sender, int id, UpdateTodoItemCommand command) =>
        {
            if (id != command.Id) return Results.BadRequest();
            await sender.Send(command);
            return Results.NoContent();
        });
        group.MapPut("UpdateDetail/{id}", async (ISender sender, int id, UpdateTodoItemDetailCommand command) =>
        {
            if (id != command.Id) return Results.BadRequest();
            await sender.Send(command);
            return Results.NoContent();
        });
        group.MapDelete("{id}", async (ISender sender, int id) =>
        {
            await sender.Send(new DeleteTodoItemCommand(id));
            return Results.NoContent();
        });
        return group;
    }
}