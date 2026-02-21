using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Dtos;

/// <summary>
/// DTO for updating an existing Game.
/// </summary>
public class GameUpdateDTO
{
    /// <summary>
    /// Updated title of the Game. Required, Min Length 3.
    /// </summary>
    [Required]
    [MinLength(3)]
    public required string Title { get; set; }

    /// <summary>
    /// Updated time for the game. Must be in the future.
    /// </summary>
    [FutureDate(ErrorMessage = "Time must not be in the past.")]
    public DateTime Time { get; set; }

    /// <summary>
    /// Updated ID of the Tournament this game belongs to.
    /// </summary>
    public int TournamentId { get; set; }
}
