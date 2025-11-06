using System.Text.Json;

namespace GPT4AllChatBot.Utils
{
    public class VideoManager
    {
        private readonly string memoryPath = "video_engine/video_memory";

        public VideoManager()
        {
            Directory.CreateDirectory(memoryPath);
        }

        public string GetNextClipName()
        {
            int count = Directory.GetFiles(memoryPath, "scene_*.mp4").Length + 1;
            return Path.Combine(memoryPath, $"scene_{count:D3}.mp4");
        }

        public void SaveMetadata(string prompt, string clipPath)
        {
            var metadataFile = Path.Combine(memoryPath, "metadata.json");
            var entry = new { prompt, clip = clipPath, timestamp = DateTime.Now };

            List<object> metadata = new();
            if (File.Exists(metadataFile))
            {
                var json = File.ReadAllText(metadataFile);
                metadata = JsonSerializer.Deserialize<List<object>>(json) ?? new List<object>();
            }

            metadata.Add(entry);
            File.WriteAllText(metadataFile, JsonSerializer.Serialize(metadata, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
