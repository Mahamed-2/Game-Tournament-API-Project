using Microsoft.EntityFrameworkCore;
using TournamentApi.Data;
using TournamentApi.Dtos;
using TournamentApi.Models;

namespace TournamentApi.Services;

/// <summary>
/// Implementation of ITournamentService using Entity Framework Core.
/// </summary>
public class TournamentService : ITournamentService
{
    private readonly TournamentDbContext _context;

    public TournamentService(TournamentDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets all tournaments, with optional title search.
    /// </summary>
    public async Task<IEnumerable<TournamentResponseDTO>> GetAllAsync(string? search)
    {
        var query = _context.Tournaments.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(t => t.Title.Contains(search));
        }

        var tournaments = await query.ToListAsync();

        return tournaments.Select(t => new TournamentResponseDTO
        {
            Id = t.Id,
            Title = t.Title,
            MaxPlayers = t.MaxPlayers,
            Date = t.Date
        });
    }

    /// <summary>
    /// Finds a tournament by ID. Returns null if not found.
    /// </summary>
    public async Task<TournamentResponseDTO?> GetByIdAsync(int id)
    {
        var tournament = await _context.Tournaments.FindAsync(id);
        if (tournament == null) return null;

        return new TournamentResponseDTO
        {
            Id = tournament.Id,
            Title = tournament.Title,
            MaxPlayers = tournament.MaxPlayers,
            Date = tournament.Date
        };
    }

    /// <summary>
    /// Adds a new tournament to the database.
    /// </summary>
    public async Task<TournamentResponseDTO> CreateAsync(TournamentCreateDTO dto)
    {
        var tournament = new Tournament
        {
            Title = dto.Title,
            Description = dto.Description,
            MaxPlayers = dto.MaxPlayers,
            Date = dto.Date
        };

        _context.Tournaments.Add(tournament);
        await _context.SaveChangesAsync();

        return new TournamentResponseDTO
        {
            Id = tournament.Id,
            Title = tournament.Title,
            MaxPlayers = tournament.MaxPlayers,
            Date = tournament.Date
        };
    }

    /// <summary>
    /// Updates tournament fields. Returns false if tournament not found.
    /// </summary>
    public async Task<bool> UpdateAsync(int id, TournamentUpdateDTO dto)
    {
        var tournament = await _context.Tournaments.FindAsync(id);
        if (tournament == null) return false;

        tournament.Title = dto.Title;
        tournament.Description = dto.Description;
        tournament.MaxPlayers = dto.MaxPlayers;
        tournament.Date = dto.Date;

        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Partially updates a tournament. Returns null if tournament not found.
    /// </summary>
    public async Task<TournamentResponseDTO?> PatchAsync(int id, TournamentPatchDTO dto)
    {
        var tournament = await _context.Tournaments.FindAsync(id);
        if (tournament == null) return null;

        if (dto.Title != null) tournament.Title = dto.Title;
        if (dto.Description != null) tournament.Description = dto.Description;
        if (dto.MaxPlayers.HasValue) tournament.MaxPlayers = dto.MaxPlayers.Value;
        if (dto.Date.HasValue) tournament.Date = dto.Date.Value;

        await _context.SaveChangesAsync();

        return new TournamentResponseDTO
        {
            Id = tournament.Id,
            Title = tournament.Title,
            MaxPlayers = tournament.MaxPlayers,
            Date = tournament.Date
        };
    }

    /// <summary>
    /// Removes a tournament from the database.
    /// </summary>
    public async Task<bool> DeleteAsync(int id)
    {
        var tournament = await _context.Tournaments.FindAsync(id);
        if (tournament == null) return false;

        _context.Tournaments.Remove(tournament);
        await _context.SaveChangesAsync();
        return true;
    }
}
