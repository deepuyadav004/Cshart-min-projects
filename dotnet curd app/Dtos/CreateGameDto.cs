using System.ComponentModel.DataAnnotations;

namespace dotnet_curd_app.Dtos;

public record class CreateGameDto(
    [Required][StringLength(50)] string name,
    [Required][StringLength(30)] string genre,
    [Range(0, 1000)] decimal price,
    [Required] DateOnly releaseDate
);
