using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Dtos;

/// <summary>
/// DTO for creating a new Tournament. Excludes Id property.
/// </summary>
public class TournamentCreateDTO
{
    /// <summary>
    /// Tournament Title. Required, Min Length 3.
    /// </summary>
    [Required]
    [MinLength(3)]
    public required string Title { get; set; }

    /// <summary>
    /// Optional description of the tournament.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Maximum number of players.
    /// </summary>
    public int MaxPlayers { get; set; }

    /// <summary>
    /// Date of the tournament. Must be in the future.
    /// </summary>
    [FutureDate(ErrorMessage = "Date must not be in the past.")]
    public DateTime Date { get; set; }
}
