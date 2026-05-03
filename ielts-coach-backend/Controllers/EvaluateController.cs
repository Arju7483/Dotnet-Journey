using ielts_coach_backend.Models;
using ielts_coach_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ielts_coach_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EvaluateController : ControllerBase
{
    private readonly AIService _aiService;
    private readonly DatabaseService _databaseService;

    public EvaluateController(AIService aiService, DatabaseService databaseService)
    {
        _aiService = aiService;
        _databaseService = databaseService;
    }

    [HttpPost("writing")]
    public async Task<IActionResult> EvaluateWriting([FromBody] WritingEvaluateRequest request, [FromQuery] string userId)
    {
        if (string.IsNullOrWhiteSpace(request.Essay))
            return BadRequest("Essay is required.");

        if (string.IsNullOrWhiteSpace(userId))
            return BadRequest("userId query parameter is required.");

        var evaluation = await _aiService.EvaluateWritingAsync(request.Essay);

        var attempt = new UserAttempt
        {
            UserId = userId,
            Type = "Writing",
            Score = evaluation.OverallScore,
            Feedback = JsonSerializer.Serialize(evaluation)
        };

        await _databaseService.CreateAttemptAsync(attempt);

        return Ok(evaluation);
    }

    [HttpPost("speaking")]
    public async Task<IActionResult> EvaluateSpeaking([FromForm] IFormFile audioFile, [FromQuery] string userId)
    {
        if (audioFile == null || audioFile.Length == 0)
            return BadRequest("Audio file is required.");

        if (string.IsNullOrWhiteSpace(userId))
            return BadRequest("userId query parameter is required.");

        var evaluation = await _aiService.EvaluateSpeakingAsync(audioFile);

        var attempt = new UserAttempt
        {
            UserId = userId,
            Type = "Speaking",
            Score = evaluation.OverallScore,
            Feedback = JsonSerializer.Serialize(evaluation)
        };

        await _databaseService.CreateAttemptAsync(attempt);

        return Ok(evaluation);
    }
}
