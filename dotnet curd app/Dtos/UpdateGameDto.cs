namespace dotnet_curd_app.Dtos;

public record class UpdateGameDto(
    string name,
    string genre,
    decimal price,
    DateOnly releaseDate
);