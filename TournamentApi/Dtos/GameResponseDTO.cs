namespace TournamentApi.Dtos;

/// <summary>
/// DTO representing a Game in a response. Includes Id and TournamentId.
/// </summary>
public class GameResponseDTO
{
    /// <summary>
    /// Game Identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of the Game.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// The specific time when this game is played.
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// ID of the associated Tournament.
    /// </summary>
    public int TournamentId { get; set; }
}
