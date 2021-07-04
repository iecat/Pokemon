using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pokemon.Api.Model
{
    public class PokemonJson
    {
        public string Name { get; set; }
        [JsonProperty(PropertyName = "is_legendary")]
        public bool IsLegendary { get; set; }
        public Habitat Habitat { get; set; }

        [JsonProperty(PropertyName = "flavor_text_entries")]
        public List<FlavorTextEntries> FlavorTextEntries { get; set; }

    }

    public class Habitat
    {
        public string Name { get; set; }
    }

    public class FlavorTextEntries
    {
        [JsonProperty(PropertyName = "flavor_text")]
        public string FlavorText { get; set; }
        public Language Language { get; set; }
    }

    public class Language
    {
        public string Name { get; set; }

    }
}
