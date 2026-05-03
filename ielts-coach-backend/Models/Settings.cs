namespace ielts_coach_backend.Models;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}

public class GeminiSettings
{
    public string ApiKey { get; set; } = string.Empty;
}
