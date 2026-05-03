using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ielts_coach_backend.Models;
using Microsoft.Extensions.Options;

namespace ielts_coach_backend.Services;

public class AIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public AIService(HttpClient httpClient, IOptions<GeminiSettings> settings)
    {
        _httpClient = httpClient;
        _apiKey = settings.Value.ApiKey;
    }

    public async Task<EvaluationResponse> EvaluateWritingAsync(string essay)
    {
        var prompt = $"Evaluate the following IELTS essay. Provide an overall score and detailed feedback in JSON format strictly following this schema: {{ \"overallScore\": 0.0, \"detailedFeedback\": \"string\" }}. Here is the essay: {essay}";

        var requestBody = new
        {
            contents = new[]
            {
                new { parts = new[] { new { text = prompt } } }
            }
        };

        return await SendGeminiRequestAsync(requestBody);
    }

    public async Task<EvaluationResponse> EvaluateSpeakingAsync(IFormFile audioFile)
    {
        using var memoryStream = new MemoryStream();
        await audioFile.CopyToAsync(memoryStream);
        var base64Audio = Convert.ToBase64String(memoryStream.ToArray());

        var prompt = "Evaluate the following IELTS speaking audio. Provide an overall score and detailed feedback in JSON format strictly following this schema: { \"overallScore\": 0.0, \"detailedFeedback\": \"string\" }.";

        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new object[]
                    {
                        new { text = prompt },
                        new
                        {
                            inline_data = new
                            {
                                mime_type = audioFile.ContentType,
                                data = base64Audio
                            }
                        }
                    }
                }
            }
        };

        return await SendGeminiRequestAsync(requestBody);
    }

    private async Task<EvaluationResponse> SendGeminiRequestAsync(object requestBody)
    {
        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={_apiKey}";

        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Gemini API error: {response.StatusCode} - {error}");
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();
        using var document = JsonDocument.Parse(jsonResponse);

        var responseText = document.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString();

        if (string.IsNullOrEmpty(responseText))
        {
            throw new Exception("Empty response from Gemini API");
        }

        // Clean up markdown formatting if Gemini wrapped it in ```json
        responseText = responseText.Replace("```json", "").Replace("```", "").Trim();

        try
        {
            var result = JsonSerializer.Deserialize<EvaluationResponse>(responseText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result ?? new EvaluationResponse { DetailedFeedback = "Failed to parse response." };
        }
        catch (JsonException ex)
        {
            throw new Exception($"Failed to parse JSON response from Gemini: {responseText}", ex);
        }
    }
}
