using Microsoft.EntityFrameworkCore;
using TournamentApi.Models;

namespace TournamentApi.Data;

/// <summary>
/// Entity Framework Core database context for the Tournament API.
/// </summary>
public class TournamentDbContext : DbContext
{
    public TournamentDbContext(DbContextOptions<TournamentDbContext> options) : base(options) { }

    /// <summary>
    /// DbSet for Tournament entities.
    /// </summary>
    public DbSet<Tournament> Tournaments { get; set; } = null!;

    /// <summary>
    /// DbSet for Game entities.
    /// </summary>
    public DbSet<Game> Games { get; set; } = null!;
}
