using dotenv.net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

DotEnv.Load();

var apiBase = Environment.GetEnvironmentVariable("GPT4ALL_API_BASE");
var modelId = Environment.GetEnvironmentVariable("MODEL_ID");

using var client = new HttpClient();
Console.WriteLine("GPT4All Chatbot ready! Type 'q' to quit.");

var conversationHistory = new List<object>
{
    new { role = "system", content = "You are a friendly and concise assistant. Give short, factual answers in a pleasant tone. Avoid storytelling or unnecessary introductions." }
};

while (true)
{
    Console.Write("\nYou: ");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "q")
    {
        Console.WriteLine("\nGoodbye!");
        break;
    }

    // CUSTOM RESPONSE
    if (input.Trim().Equals("What is love?", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("\nAI: 🎵 Baby don't hurt me! 🎵");
        continue;
    }

    // Add user message
    conversationHistory.Add(new { role = "user", content = input });

    // Keep only the last 10 messages to avoid too long history
    var messagesToSend = conversationHistory.Skip(Math.Max(0, conversationHistory.Count - 10)).ToList();

    var payload = new
    {
        model = modelId,
        messages = messagesToSend,
        max_tokens = 50,
        temperature = 0.25
    };

    try
    {
        var response = await client.PostAsJsonAsync($"{apiBase}/chat/completions", payload);
        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync();
        var json = await JsonDocument.ParseAsync(stream);

        var assistantMessage = json.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        Console.WriteLine($"\nAI: {assistantMessage}");

        // Add AI message to history
        conversationHistory.Add(new { role = "assistant", content = assistantMessage });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
