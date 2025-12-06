using dotnet_curd_app.Dtos;
using dotnet_curd_app.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
