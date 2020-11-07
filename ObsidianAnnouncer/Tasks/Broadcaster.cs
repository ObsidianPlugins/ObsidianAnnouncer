using Obsidian.API;
using ObsidianAnnouncer.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace ObsidianAnnouncer.Tasks
{
    public class Broadcaster
    {
        private static bool isBroadcasting;
        public static async Task StartBroadcasting()
        {
            if (isBroadcasting) return;
            isBroadcasting = true;

            while (isBroadcasting)
            {
                if (Globals.Config.Messages.Count > 0 && Globals.Server.Players.Count() >= Globals.Config.MinPlayers)
                {
                    foreach (var msg in Globals.Config.Messages)
                    {
                        var finalMsg = IChatMessage.CreateNew();
                        finalMsg.Text = string.Empty;

                        msg.ForEach(x => finalMsg.AddExtra(chatMessage: x?.ConvertToIChatMessage()));

                        foreach (var player in Globals.Server.Players)
                            await player.SendMessageAsync(finalMsg);
                        await Task.Delay(Globals.Config.Interval * 1000);
                    }
                }
            }
        }
        public static void StopBroadcasting()
        {
            isBroadcasting = false;
        }
    }
}
