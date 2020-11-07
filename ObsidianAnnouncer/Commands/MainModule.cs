using Obsidian.API;
using Obsidian.CommandFramework.Attributes;
using Obsidian.CommandFramework.Entities;
using ObsidianAnnouncer.Tasks;
using ObsidianAnnouncer.Types;
using System;
using System.Threading.Tasks;

namespace ObsidianAnnouncer.Commands
{
    public class MainModule : BaseCommandClass
    {
        [Command("oa")]
        public async Task TestCmd(ObsidianContext ctx, string arg)
        {
            switch (arg)
            {
                case "reload":
                    try
                    {
                        Globals.Config = await ConfigManager.LoadConfig();
                        await ctx.Player.SendMessageAsync($"§aConfig reloaded successfully");
                        await Broadcaster.StartBroadcasting();
                    }
                    catch (Exception e)
                    {
                        await ctx.Player.SendMessageAsync($"§cAn error occurred when loading a config. Broadcasting stopped\n{e.Message}");
                        Broadcaster.StopBroadcasting();
                    }
                    break;

                default:
                case "about":

                    var msg = IChatMessage.CreateNew();
                    msg.Text = "§aObsidian Announcer §f- §dInterval auto announcement for JSON messages";
                    var clickComponent = ITextComponent.CreateNew();
                    clickComponent.Action = ETextAction.OpenUrl;
                    clickComponent.Value = "https://github.com/roxxel/ObsidianAnnouncer";

                    var hoverComponent = ITextComponent.CreateNew();
                    hoverComponent.Action = ETextAction.ShowText;
                    hoverComponent.Value = "§aPlugin github repo";

                    msg.HoverEvent = hoverComponent;
                    msg.ClickEvent = clickComponent;
                    await ctx.Player.SendMessageAsync(msg);
                    break;
            }
        }
    }
}
