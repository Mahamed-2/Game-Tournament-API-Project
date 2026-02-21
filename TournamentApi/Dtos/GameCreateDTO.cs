using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Dtos;

/// <summary>
/// DTO for creating a new Game. Excludes Id property.
/// </summary>
public class GameCreateDTO
{
    /// <summary>
    /// Title of the Game. Required, Min Length 3.
    /// </summary>
    [Required]
    [MinLength(3)]
    public required string Title { get; set; }

    /// <summary>
    /// Specific time for the game. Must be in the future.
    /// </summary>
    [FutureDate(ErrorMessage = "Time must not be in the past.")]
    public DateTime Time { get; set; }

    /// <summary>
    /// ID of the Tournament this game belongs to.
    /// </summary>
    public int TournamentId { get; set; }
}
