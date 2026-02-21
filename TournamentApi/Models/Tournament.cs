using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Models;

/// <summary>
/// Represents a Tournament entity in the database.
/// </summary>
public class Tournament
{
    /// <summary>
    /// Unique identifier for the Tournament.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of the Tournament. Required, minimum length 3.
    /// </summary>
    [Required]
    [MinLength(3)]
    public required string Title { get; set; }

    /// <summary>
    /// Brief description of the Tournament.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Maximum number of players allowed in the tournament.
    /// </summary>
    public int MaxPlayers { get; set; }

    /// <summary>
    /// The date when the tournament takes place.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Navigation Property for the games associated with this tournament.
    /// </summary>
    public ICollection<Game> Games { get; set; } = new List<Game>();
}
