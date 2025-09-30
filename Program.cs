using dotenv.net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

DotEnv.Load();

var apiBase = Environment.GetEnvironmentVariable("GPT4ALL_API_BASE");
var modelId = Environment.GetEnvironmentVariable("MODEL_ID");

using var client = new HttpClient();
Console.WriteLine("GPT4All Chatbot ready! Type 'q' to quit.");

while (true)
{
    Console.Write("\nYou: ");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "q")
        break;

    // CUSTOM RESPONSE
    if (input.Trim().Equals("What is love?", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("\nAI: 🎵 Baby don't hurt me! 🎵");
        continue;
    }

    // Build the JSON payload for GPT4All
    var payload = new
    {
        model = modelId,
        messages = new[]
        {
            new { role = "system", content = "You are a helpful assistant." },
            new { role = "user", content = input }
        },
        max_tokens = 1024
    };

    try
    {
        var response = await client.PostAsJsonAsync($"{apiBase}/chat/completions", payload);
        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync();
        var json = await JsonDocument.ParseAsync(stream);

        // Extract the assistant message
        var assistantMessage = json.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        Console.WriteLine($"\nAI: {assistantMessage}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
