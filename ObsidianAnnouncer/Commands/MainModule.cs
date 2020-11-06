using Newtonsoft.Json;
using Obsidian.API;
using Obsidian.CommandFramework.Attributes;
using Obsidian.CommandFramework.Entities;
using ObsidianAnnouncer.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ObsidianAnnouncer.Extensions;

namespace ObsidianAnnouncer.Commands
{
    public class MainModule : BaseCommandClass
    {
        //For testing purposes, will be deleted soon
        [Command("test")]
        public async Task TestCmd(ObsidianContext ctx)
        {
            var json = "[[{\"text\":\" 12321gdsagdashgdahdghhds\",\"clickEvent\":{\"action\":\"open_url\", \"value\":\"https:\\/\\/www.youtube.com\\/watch?v=dQw4w9WgXcQ\"},\"hoverEvent\":{\"action\":\"show_text\",\"value\":\"100% NOT A RICKROLL\"}}]]";
            var msgs = JsonConvert.DeserializeObject<List<List<Message>>>(json);
            foreach (var msg in msgs)
            {
                var finalMsg = IChatMessage.CreateNew();
                finalMsg.Text = "";
                var tempMsg = IChatMessage.CreateNew();

                msg.ForEach(x => finalMsg.AddExtra(chatMessage: x.ConvertToIChatMessage()));
                await ctx.Player.SendMessageAsync(finalMsg);
                
            }
        }
    }
}
