using Obsidian.API;
using Obsidian.API.Plugins;
using Obsidian.API.Plugins.Services;
using ObsidianAnnouncer.Commands;
using ObsidianAnnouncer.Tasks;
using ObsidianAnnouncer.Types;
using System;
using System.Threading.Tasks;

namespace ObsidianAnnouncer
{
    [Plugin(Authors = "Roxxel",
        Description = "Interval auto annoucement JSON messages",
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
            Globals.Server = server;
            Broadcaster.Initialize();
            try
            {
                Globals.Config = await ConfigManager.LoadConfig();
                await Broadcaster.StartBroadcasting();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            Logger.Log($"Loaded {Info.Name}");
            await Task.CompletedTask;
        }
    }
}
