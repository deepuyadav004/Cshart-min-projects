using System;
using dotnet_curd_app.Dtos;

namespace dotnet_curd_app.Endpoints;

public static class GamesEndpoints
{
    
    const string getGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = new()
    {
        new GameDto(1, "The Legend of Zelda: Breath of the Wild", "Action-adventure", 59.99m, new DateOnly(2017, 3, 3)),
        new GameDto(2, "God of War", "Action-adventure", 39.99m, new DateOnly(2018, 4, 20)),
        new GameDto(3, "Red Dead Redemption 2", "Action-adventure", 59.99m, new DateOnly(2018, 10, 26)),
        new GameDto(4, "Minecraft", "Sandbox", 26.95m, new DateOnly(2011, 11, 18)),
        new GameDto(5, "The Witcher 3: Wild Hunt", "Action RPG", 49.99m, new DateOnly(2015, 5, 19))
    };

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        
        var group = app.MapGroup("/games").WithParameterValidation();
        // this endpoint will return all games
        group.MapGet("/", () => games);

        // this endpoint will return a game by id
        group.MapGet("/{id}", (int id) => {
            GameDto? gameDto = games.Find(game => game.id == id);
            return gameDto is not null ? Results.Ok(gameDto) : Results.NotFound();
        }).WithName(getGameEndpointName);

        // this endpoint will create a new game
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto gameToAdd = new(
                id: games.Count + 1,
                name: newGame.name,
                genre: newGame.genre,
                price: newGame.price,
                releaseDate: newGame.releaseDate
            );
            games.Add(gameToAdd);
            return Results.CreatedAtRoute(getGameEndpointName, new { id = gameToAdd.id }, gameToAdd);
        });

        // this endpoint will update an existing game
        group.MapPut("/{id}", (int id, UpdateGameDto updateGameDto) =>
        {
            var gameIndex = games.FindIndex(game => game.id == id);
            if (gameIndex == -1)
            {
                return Results.NotFound();
            }

            games[gameIndex] = new GameDto(
                id: id,
                name: updateGameDto.name,
                genre: updateGameDto.genre,
                price: updateGameDto.price,
                releaseDate: updateGameDto.releaseDate
            );
            return Results.NoContent();
        });


        // this endpoint will delete a game
        group.MapDelete("/{id}", (int id) =>
        {
            var gameIndex = games.FindIndex(game => game.id == id);
            if (gameIndex == -1)
            {
                return Results.NotFound();
            }

            games.RemoveAt(gameIndex);
            return Results.NoContent();
        });


        return group;
    }

}
