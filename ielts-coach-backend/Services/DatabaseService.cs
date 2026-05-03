using ielts_coach_backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ielts_coach_backend.Services;

public class DatabaseService
{
    private readonly IMongoCollection<UserAttempt> _userAttempts;

    public DatabaseService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var settings = mongoDbSettings.Value;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        
        _userAttempts = database.GetCollection<UserAttempt>("UserAttempts");
    }

    public async Task<List<UserAttempt>> GetUserHistoryAsync(string userId)
    {
        return await _userAttempts.Find(x => x.UserId == userId)
                                  .SortByDescending(x => x.CreatedAt)
                                  .ToListAsync();
    }

    public async Task CreateAttemptAsync(UserAttempt attempt)
    {
        await _userAttempts.InsertOneAsync(attempt);
    }
}
