using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record UpdateGameDto(
    [Required, MinLength(1), MaxLength(100)]
    string Name,
    int GenreId,
 
    [Required, Range(typeof(decimal), "0.01", "1000.00")]
    decimal Price,

    [Required]
    DateOnly ReleaseDate
    );