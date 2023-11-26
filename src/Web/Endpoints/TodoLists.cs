using MyAwesomeDotnetDockerApp.Application.TodoLists.Commands.CreateTodoList;
using MyAwesomeDotnetDockerApp.Application.TodoLists.Commands.DeleteTodoList;
using MyAwesomeDotnetDockerApp.Application.TodoLists.Commands.UpdateTodoList;
using MyAwesomeDotnetDockerApp.Application.TodoLists.Queries.GetTodos;

namespace MyAwesomeDotnetDockerApp.Web.Endpoints;

public static class TodoLists 
{
    public static RouteGroupBuilder MapTodoLists(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/TodoLists");
        group.WithTags("Todos");
        group.RequireAuthorization();
        group.MapGet("/", async (ISender sender) => await sender.Send(new GetTodosQuery()));
        group.MapPost("/", async (ISender sender, CreateTodoListCommand command) => await sender.Send(command));
        group.MapPut("{id}", async (ISender sender, int id, UpdateTodoListCommand command) =>
        {
            if (id != command.Id) return Results.BadRequest();
            await sender.Send(command);
            return Results.NoContent();
        });
        group.MapDelete("{id}", async (ISender sender, int id) =>
        {
            await sender.Send(new DeleteTodoListCommand(id));
            return Results.NoContent();
        });
        return group;
    }
}