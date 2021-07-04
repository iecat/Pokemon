using Newtonsoft.Json;
using Pokemon.Api.Interfaces;
using Pokemon.Api.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokemon.Api.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IHttpClientFactory _clientFactory;
        public PokemonService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Pokemon.Api.Model.PokemonJson> GetPokemon(string name)
        {
            HttpRequestMessage rerquest = new HttpRequestMessage(HttpMethod.Get, new Uri($"https://pokeapi.co/api/v2/pokemon-species/{name}"));

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(rerquest);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            var responseString = await response.Content.ReadAsStringAsync();
            var pokemonJson = JsonConvert.DeserializeObject<PokemonJson>(responseString);
            return pokemonJson;
        }

    }
}
