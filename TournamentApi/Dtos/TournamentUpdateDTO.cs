using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Dtos;

/// <summary>
/// DTO for updating an existing Tournament.
/// </summary>
public class TournamentUpdateDTO
{
    /// <summary>
    /// Updated Tournament Title. Required, Min Length 3.
    /// </summary>
    [Required]
    [MinLength(3)]
    public required string Title { get; set; }

    /// <summary>
    /// Optional updated description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Updated maximum number of players.
    /// </summary>
    public int MaxPlayers { get; set; }

    /// <summary>
    /// Updated date of the tournament. Must be in the future.
    /// </summary>
    [FutureDate(ErrorMessage = "Date must not be in the past.")]
    public DateTime Date { get; set; }
}
