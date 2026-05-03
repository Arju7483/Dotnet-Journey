using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ielts_coach_backend.Models;

public class UserAttempt
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public required string UserId { get; set; }

    public required string Type { get; set; } // "Writing" or "Speaking"

    public float Score { get; set; }

    public required string Feedback { get; set; } // JSON string of the evaluation response

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
