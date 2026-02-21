using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Models;

/// <summary>
/// Represents a Game entity in the database.
/// </summary>
public class Game
{
    /// <summary>
    /// Unique identifier for the Game.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of the Game. Required, minimum length 3.
    /// </summary>
    [Required]
    [MinLength(3)]
    public required string Title { get; set; }

    /// <summary>
    /// The specific time when this game is played.
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// Foreign Key to the parent Tournament.
    /// </summary>
    public int TournamentId { get; set; }

    /// <summary>
    /// Navigation Property back to the associated Tournament.
    /// </summary>
    public Tournament Tournament { get; set; } = null!;
}
