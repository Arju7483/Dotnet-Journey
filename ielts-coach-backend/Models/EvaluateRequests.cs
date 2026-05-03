namespace ielts_coach_backend.Models;

public class WritingEvaluateRequest
{
    public required string Essay { get; set; }
}

public class EvaluationResponse
{
    public float OverallScore { get; set; }
    public required string DetailedFeedback { get; set; }
}
