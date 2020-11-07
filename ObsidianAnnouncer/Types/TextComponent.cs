using Newtonsoft.Json;
using Obsidian.API;
using ObsidianAnnouncer.Extensions.Converter;

namespace ObsidianAnnouncer.Types
{
    //This also stolen from obsidian repo don't judge me :) 
    public class TextComponent : ITextComponent
    {
        [JsonProperty("action"), JsonConverter(typeof(DefaultEnumConverter<ETextAction>))]
        public ETextAction Action { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("translate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Translate { get; set; }
    }
}
