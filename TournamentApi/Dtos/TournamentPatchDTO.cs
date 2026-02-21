using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Dtos;

/// <summary>
/// DTO for partially updating an existing Tournament.
/// </summary>
public class TournamentPatchDTO
{
    /// <summary>
    /// Updated Tournament Title. Min Length 3 if provided.
    /// </summary>
    [MinLength(3)]
    public string? Title { get; set; }

    /// <summary>
    /// Optional updated description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Updated maximum number of players.
    /// </summary>
    public int? MaxPlayers { get; set; }

    /// <summary>
    /// Updated date of the tournament.
    /// </summary>
    [FutureDate(ErrorMessage = "Date must not be in the past.")]
    public DateTime? Date { get; set; }
}
