using Microsoft.EntityFrameworkCore;
using TournamentApi.Data;
using TournamentApi.Dtos;
using TournamentApi.Models;

namespace TournamentApi.Services;

/// <summary>
/// Implementation of IGameService using Entity Framework Core.
/// </summary>
public class GameService : IGameService
{
    private readonly TournamentDbContext _context;

    public GameService(TournamentDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets all games from the database.
    /// </summary>
    public async Task<IEnumerable<GameResponseDTO>> GetAllAsync()
    {
        var games = await _context.Games.ToListAsync();

        return games.Select(g => new GameResponseDTO
        {
            Id = g.Id,
            Title = g.Title,
            Time = g.Time,
            TournamentId = g.TournamentId
        });
    }

    /// <summary>
    /// Finds a game by ID. Returns null if not found.
    /// </summary>
    public async Task<GameResponseDTO?> GetByIdAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return null;

        return new GameResponseDTO
        {
            Id = game.Id,
            Title = game.Title,
            Time = game.Time,
            TournamentId = game.TournamentId
        };
    }

    /// <summary>
    /// Adds a new game. Validates that the associated tournament exists.
    /// </summary>
    public async Task<GameResponseDTO?> CreateAsync(GameCreateDTO dto)
    {
        // Check if tournament exists
        var tournamentExists = await _context.Tournaments.AnyAsync(t => t.Id == dto.TournamentId);
        if (!tournamentExists) return null;

        var game = new Game
        {
            Title = dto.Title,
            Time = dto.Time,
            TournamentId = dto.TournamentId
        };

        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        return new GameResponseDTO
        {
            Id = game.Id,
            Title = game.Title,
            Time = game.Time,
            TournamentId = game.TournamentId
        };
    }

    /// <summary>
    /// Updates game fields. Validates tournament existence if ID changed.
    /// </summary>
    public async Task<bool> UpdateAsync(int id, GameUpdateDTO dto)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return false;

        var tournamentExists = await _context.Tournaments.AnyAsync(t => t.Id == dto.TournamentId);
        if (!tournamentExists) return false;

        game.Title = dto.Title;
        game.Time = dto.Time;
        game.TournamentId = dto.TournamentId;

        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Removes a game from the database.
    /// </summary>
    public async Task<bool> DeleteAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return false;

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        return true;
    }
}
