using ielts_coach_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ielts_coach_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HistoryController : ControllerBase
{
    private readonly DatabaseService _databaseService;

    public HistoryController(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetHistory(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            return BadRequest("userId is required.");

        var history = await _databaseService.GetUserHistoryAsync(userId);
        return Ok(history);
    }
}
