using Obsidian.API;
using Obsidian.API.Plugins;
using Obsidian.API.Plugins.Services;
using ObsidianAnnouncer.Commands;
using System.Threading.Tasks;

namespace ObsidianAnnouncer
{
    [Plugin(Authors = "Roxxel",
        Description = "Interval auto annoucement",
        Name = "Obsidian Announcer",
        ProjectUrl = "https://github.com/roxxel/ObsidianAnnouncer",
        Version = "0.1")]
    public class Plugin : PluginBase
    {
        [Inject] public ILogger Logger { get; set; }
        [Inject] public IFileReader FileReader { get; set; }
        [Inject] public IFileWriter FileWriter { get; set; }


        public async Task OnLoad(IServer server)
        {
            server.RegisterCommandClass<MainModule>();
            Globals.Logger = Logger;
            Globals.FileWriter = FileWriter;
            Globals.FileReader = FileReader;


            Logger.Log($"Loaded {Info.Name}");
            await Task.CompletedTask;
        }
    }
}
