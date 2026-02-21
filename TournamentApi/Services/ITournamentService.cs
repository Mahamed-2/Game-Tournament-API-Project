using TournamentApi.Dtos;

namespace TournamentApi.Services;

/// <summary>
/// Service interface for managing Tournaments.
/// </summary>
public interface ITournamentService
{
    /// <summary>
    /// Retrieves all tournaments, optionally filtered by title.
    /// </summary>
    Task<IEnumerable<TournamentResponseDTO>> GetAllAsync(string? search);

    /// <summary>
    /// Retrieves a specific tournament by its ID.
    /// </summary>
    Task<TournamentResponseDTO?> GetByIdAsync(int id);

    /// <summary>
    /// Creates a new tournament.
    /// </summary>
    Task<TournamentResponseDTO> CreateAsync(TournamentCreateDTO dto);

    /// <summary>
    /// Updates an existing tournament.
    /// </summary>
    Task<bool> UpdateAsync(int id, TournamentUpdateDTO dto);

    /// <summary>
    /// Partially updates an existing tournament.
    /// </summary>
    Task<TournamentResponseDTO?> PatchAsync(int id, TournamentPatchDTO dto);

    /// <summary>
    /// Deletes a tournament by its ID.
    /// </summary>
    Task<bool> DeleteAsync(int id);
}
