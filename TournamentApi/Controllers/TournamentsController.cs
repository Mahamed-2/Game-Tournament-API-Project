using Microsoft.AspNetCore.Mvc;
using TournamentApi.Dtos;
using TournamentApi.Services;

namespace TournamentApi.Controllers;

/// <summary>
/// Controller for managing Tournaments via HTTP requests.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TournamentsController : ControllerBase
{
    private readonly ITournamentService _service;

    public TournamentsController(ITournamentService service)
    {
        _service = service;
    }

    /// <summary>
    /// GET: api/tournaments?search={term}
    /// Returns all tournaments, optionally filtered by title.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TournamentResponseDTO>>> GetAll([FromQuery] string? search)
    {
        var tournaments = await _service.GetAllAsync(search);
        return Ok(tournaments);
    }

    /// <summary>
    /// GET: api/tournaments/{id}
    /// Returns a specific tournament by ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<TournamentResponseDTO>> GetById(int id)
    {
        var tournament = await _service.GetByIdAsync(id);
        if (tournament == null) return NotFound();

        return Ok(tournament);
    }

    /// <summary>
    /// POST: api/tournaments
    /// Creates a new tournament from the provided DTO.
    /// </summary>
    [HttpPost]
    [Microsoft.AspNetCore.RateLimiting.EnableRateLimiting("PostPolicy")]
    public async Task<ActionResult<TournamentResponseDTO>> Create(TournamentCreateDTO dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// PUT: api/tournaments/{id}
    /// Updates an existing tournament.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TournamentUpdateDTO dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();

        return NoContent();
    }

    /// <summary>
    /// PATCH: api/tournaments/{id}
    /// Partially updates an existing tournament.
    /// </summary>
    [HttpPatch("{id}")]
    public async Task<ActionResult<TournamentResponseDTO>> Patch(int id, TournamentPatchDTO dto)
    {
        var updated = await _service.PatchAsync(id, dto);
        if (updated == null) return NotFound();

        return Ok(updated);
    }

    /// <summary>
    /// DELETE: api/tournaments/{id}
    /// Deletes a specific tournament. Requires JWT Authorization.
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
