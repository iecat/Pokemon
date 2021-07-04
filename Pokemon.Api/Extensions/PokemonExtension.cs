using Pokemon.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Api.Extensions
{
    public static class PokemonExtension
    {
        public static Pokemon.Api.Model.Pokemon ToPokemon(this PokemonJson pokemonJson)
        {
            return new Model.Pokemon()
            {
                Name = pokemonJson.Name,
                Description = pokemonJson.FlavorTextEntries.FirstOrDefault(txt => txt.Language.Name == "en")?.FlavorText,
                Habitat = pokemonJson.Habitat.Name,
                IsLegendary = pokemonJson.IsLegendary
            };
        }
    }
}
