namespace dotnet_curd_app.Dtos;

public record class GameDto(
    int id,
    string name,
    string genre,
    decimal price,
    DateOnly releaseDate
);
