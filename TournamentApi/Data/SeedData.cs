using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TournamentApi.Models;

namespace TournamentApi.Data;

/// <summary>
/// Utility class to seed the database with initial data on startup.
/// </summary>
public static class SeedData
{
    /// <summary>
    /// Initializes the database with dummy data if it's currently empty.
    /// </summary>
    /// <param name="serviceProvider">The service provider to resolve dependencies.</param>
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        // Get the database context from the service provider
        using var context = new TournamentDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<TournamentDbContext>>());

        // Ensure the database is created
        await context.Database.EnsureCreatedAsync();

        // Check if there are any existing Tournaments
        if (await context.Tournaments.AnyAsync())
        {
            return; // Database has been seeded already
        }

        // --- Seed Data ---

        var tournaments = new List<Tournament>
        {
            new Tournament
            {
                Title = "Grand Winter Open 2026",
                Description = "Our flagship annual winter tournament with pro players.",
                MaxPlayers = 64,
                Date = DateTime.UtcNow.AddMonths(10),
                Games = new List<Game>
                {
                    new Game { Title = "Opening Round: Alpha vs Beta", Time = DateTime.UtcNow.AddMonths(10).AddHours(2) },
                    new Game { Title = "Quarter Final: Group A", Time = DateTime.UtcNow.AddMonths(10).AddHours(6) }
                }
            },
            new Tournament
            {
                Title = "Summer Blitz Championship",
                Description = "Fast-paced tournament for community members.",
                MaxPlayers = 32,
                Date = DateTime.UtcNow.AddMonths(5),
                Games = new List<Game>
                {
                    new Game { Title = "Blitz Round 1", Time = DateTime.UtcNow.AddMonths(5).AddHours(1) },
                    new Game { Title = "Blitz Semis", Time = DateTime.UtcNow.AddMonths(5).AddHours(3) }
                }
            }
        };

        // Add to context and save
        await context.Tournaments.AddRangeAsync(tournaments);
        await context.SaveChangesAsync();
    }
}
