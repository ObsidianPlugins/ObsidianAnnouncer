using Obsidian.API;
using ObsidianAnnouncer.Extensions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObsidianAnnouncer.Tasks
{
    public class Broadcaster
    {
        private static CancellationTokenSource cts = new CancellationTokenSource();
        private static CancellationToken ct;
        private static bool isBroadcasting = false;
        public static void Initialize()
        {
            ct = cts.Token;
        }
        public static readonly Task BroadcastTask = new Task(async () =>
        {
            Globals.Logger.Log("Broadcasting started");
            while (!ct.IsCancellationRequested)
            {

                if (Globals.Config.Messages.Count > 0 && Globals.Server.Players.Count() >= Globals.Config.MinPlayers)
                {
                    foreach (var msg in Globals.Config.Messages)
                    {
                        if (ct.IsCancellationRequested)
                        {
                            ct.ThrowIfCancellationRequested();
                            Globals.Logger.Log("Broadcasting stopped");
                        }


                        var finalMsg = IChatMessage.CreateNew();
                        finalMsg.Text = string.Empty;

                        msg.ForEach(x => finalMsg.AddExtra(chatMessage: x?.ConvertToIChatMessage()));

                        foreach (var player in Globals.Server.Players)
                            await player.SendMessageAsync(finalMsg);
                        await Task.Delay(Globals.Config.Interval * 1000);
                    }
                }
            }
        });
        public async static Task StartBroadcasting()
        {
            if (!isBroadcasting)
            {
                try
                {
                    Globals.Logger.Log("Trying to start broadcast");
                    BroadcastTask.Start();
                    isBroadcasting = true;
                }
                catch (OperationCanceledException e)
                {
                    isBroadcasting = false;
                }

            }

        }
        public static void StopBroadcasting()
        {
            cts.Cancel();
        }
    }
}
