using Newtonsoft.Json;
using Obsidian.API;
using ObsidianAnnouncer.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObsidianAnnouncer.Types
{
    //Stolen from Obsidian repo
    public class Message : IChatMessage
    { 
        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Color { get; set; }
        [JsonProperty("text", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("bold", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Bold { get; set; }

        [JsonProperty("italic", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Italic { get; set; }

        [JsonProperty("underlined", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Underline { get; set; }

        [JsonProperty("strikethrough", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Strikethrough { get; set; }

        [JsonProperty("obfuscated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Obfuscated { get; set; }

        [JsonProperty("insertion", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Insertion { get; set; }

        [JsonProperty("clickEvent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TextComponent ClickEvent { get; set; }

        [JsonProperty("hoverEvent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TextComponent HoverEvent { get; set; }

        [JsonProperty("extra", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<Message> Extra { get; set; }

        [JsonIgnore]
        public IEnumerable<IChatMessage> Extras => GetExtras();

        ITextComponent IChatMessage.ClickEvent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        ITextComponent IChatMessage.HoverEvent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public ITextComponent IChatMessage.ClickEvent { get => this.ConvertToHoverITextComponent(); set => HoverEvent = (TextComponent)value; }
        //ITextComponent IChatMessage.HoverEvent { get => HoverEvent; set => HoverEvent = (TextComponent)value; }

        public IEnumerable<IChatMessage> GetExtras()
        {
            foreach (var extra in Extra)
            {
                yield return extra;
            }
        }

        /// <summary>
        /// Creates a new <see cref="ChatMessage"/> object with plain text.
        /// </summary>
        public static Message Simple(string text) => new Message() { Text = text };

        public Message AddExtra(Message message)
        {
            Extra ??= new List<Message>();
            Extra.Add(message);

            return this;
        }

        public Message AddExtra(List<Message> messages)
        {
            Extra ??= new List<Message>(capacity: messages.Count);
            Extra.AddRange(messages);

            return this;
        }

        public IChatMessage AddExtra(IChatMessage message)
        {
            return AddExtra(message as Message);
        }

        public IChatMessage AddExtra(IEnumerable<IChatMessage> messages)
        {
            foreach (var message in messages)
            {
                AddExtra(message);
            }

            return this;
        }

        public static implicit operator Message(string text) => Simple(text);
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
