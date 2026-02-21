using TournamentApi.Dtos;

namespace TournamentApi.Services;

/// <summary>
/// Service interface for managing Games.
/// </summary>
public interface IGameService
{
    /// <summary>
    /// Retrieves all games.
    /// </summary>
    Task<IEnumerable<GameResponseDTO>> GetAllAsync();

    /// <summary>
    /// Retrieves a specific game by its ID.
    /// </summary>
    Task<GameResponseDTO?> GetByIdAsync(int id);

    /// <summary>
    /// Creates a new game.
    /// </summary>
    Task<GameResponseDTO?> CreateAsync(GameCreateDTO dto);

    /// <summary>
    /// Updates an existing game.
    /// </summary>
    Task<bool> UpdateAsync(int id, GameUpdateDTO dto);

    /// <summary>
    /// Deletes a game by its ID.
    /// </summary>
    Task<bool> DeleteAsync(int id);
}
