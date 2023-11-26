using MyAwesomeDotnetDockerApp.Web.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

var app = builder.Build();
app.UseHealthChecks("/health");
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();
app.MapWeatherForecasts();
app.MapUsers();
app.MapTodoLists();
app.MapTodoItems();
app.Map("/", () => Results.Redirect("/swagger"));
app.Run();

public partial class Program { }
