using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ObsidianAnnouncer.Types
{
    public class Config
    {
        [JsonProperty("interval", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Interval { get; set; } = 45;

        [JsonProperty("min_players", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MinPlayers { get; set; } = 1;

        [JsonProperty("messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<List<Message>> Messages = new List<List<Message>>();

    }
    public static class ConfigManager
    {
        public static async Task<Config> LoadConfig()
        {
            var path = Path.Combine(Globals.GetWorkingDirectory, "config.json");
            if (!Globals.FileReader.FileExists(path))
            {
                Globals.FileWriter.CreateFile(path);
                Globals.FileWriter.WriteAllText(path, JsonConvert.SerializeObject(new Config(), Formatting.Indented));
            }
            var json = await Globals.FileReader.ReadAllTextAsync(path);

            Config config = JsonConvert.DeserializeObject<Config>(json);

            if (config.Interval <= 0) config.Interval = 45;
            if (config.MinPlayers < 0) config.MinPlayers = 0;
            return config;
        }

    }
}
