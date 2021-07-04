using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Pokemon.Api.Tests.Integration
{
    public class PokemonControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        HttpClient _client { get; }
        public PokemonControllerTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }
        [Fact]
        public async Task Get_Should_Retrieve_Pokemon()
        {
            var response = await _client.GetAsync("/pokemon/ditto");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var pokemonResp = JsonConvert.DeserializeObject<Pokemon.Api.Model.Pokemon>(await response.Content.ReadAsStringAsync());
            Assert.Equal("ditto", pokemonResp.Name);
            //rest of assertations for description, is legendary, habitat
        }

        [Fact]
        public async Task Get_Should_Retrieve_NotFound_ForPokemonInvalid()
        {
            var response = await _client.GetAsync("/pokemon/ditto11");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
