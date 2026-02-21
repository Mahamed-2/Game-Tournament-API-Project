namespace TournamentApi.Dtos;

/// <summary>
/// DTO representing a Tournament in a response. Includes Id but excludes Description.
/// </summary>
public class TournamentResponseDTO
{
    /// <summary>
    /// Tournament Identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Tournament Title.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Maximum number of players allowed.
    /// </summary>
    public int MaxPlayers { get; set; }

    /// <summary>
    /// Date of the tournament.
    /// </summary>
    public DateTime Date { get; set; }
}
