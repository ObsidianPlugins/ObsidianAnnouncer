using Obsidian.API;
using ObsidianAnnouncer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObsidianAnnouncer.Extensions
{
    public static class MessageExtension
    {
        public static IChatMessage ConvertToIChatMessage(this Message message)
        {
            var tmp = IChatMessage.CreateNew();

            tmp.Bold = message.Bold;
            tmp.ClickEvent = message.ClickEvent;
            tmp.HoverEvent = message.HoverEvent;
            tmp.Insertion = message.Insertion;
            tmp.Italic = message.Italic;
            tmp.Obfuscated = message.Obfuscated;
            tmp.Strikethrough = message.Strikethrough;
            var color = Globals.Colors.TryGetValue(message.Color ?? "", out var _color) ? $"§{_color}" : "";
            tmp.Text = $"{color}{message.Text}";
            tmp.Underline = message.Underline;
            tmp.HoverEvent = message.HoverEvent;
            tmp.ClickEvent = message.ClickEvent;

            return tmp;

        }
        
    }
}
