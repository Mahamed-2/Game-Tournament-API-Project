using Microsoft.AspNetCore.Mvc;
using TournamentApi.Dtos;
using TournamentApi.Services;

namespace TournamentApi.Controllers;

/// <summary>
/// Controller for managing Games via HTTP requests.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _service;

    public GamesController(IGameService service)
    {
        _service = service;
    }

    /// <summary>
    /// GET: api/games
    /// Returns all games.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameResponseDTO>>> GetAll()
    {
        var games = await _service.GetAllAsync();
        return Ok(games);
    }

    /// <summary>
    /// GET: api/games/{id}
    /// Returns a specific game by ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<GameResponseDTO>> GetById(int id)
    {
        var game = await _service.GetByIdAsync(id);
        if (game == null) return NotFound();

        return Ok(game);
    }

    /// <summary>
    /// POST: api/games
    /// Creates a new game. Checks tournament existence.
    /// </summary>
    [HttpPost]
    [Microsoft.AspNetCore.RateLimiting.EnableRateLimiting("PostPolicy")]
    public async Task<ActionResult<GameResponseDTO>> Create(GameCreateDTO dto)
    {
        var created = await _service.CreateAsync(dto);
        if (created == null) return BadRequest("Tournament not found.");

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// PUT: api/games/{id}
    /// Updates an existing game.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, GameUpdateDTO dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound("Game or Tournament not found.");

        return NoContent();
    }

    /// <summary>
    /// DELETE: api/games/{id}
    /// Deletes a specific game. Requires JWT Authorization.
    /// </summary>
    [HttpDelete("{id}")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
