using Newtonsoft.Json;

namespace Pokemon.Api.Model
{
    public class TranslationJson
    {
        [JsonProperty(PropertyName = "contents")]
        public Contents Content { get; set; }
    }
    public class Contents 
    {
        [JsonProperty(PropertyName = "translated")]

        public string Translated { get; set; }
    }
}
