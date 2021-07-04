using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemon.Api.Extensions;
using Pokemon.Api.Interfaces;

namespace Pokemon.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonService _pokemonService;
        private readonly ITranslatePokemon _translatePokemon;

        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemonService, ITranslatePokemon translatePokemon)
        {
            _logger = logger;
            _pokemonService = pokemonService;
            _translatePokemon = translatePokemon;
        }

        [Route("{name}")]
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var pokemonJson = await _pokemonService.GetPokemon(name);

            if (pokemonJson == null) return NotFound();

            return Ok(pokemonJson.ToPokemon());
        }

        [Route("translated/{name}")]
        [HttpGet]
        public async Task<IActionResult> Translate(string name)
        {
            var pokemonJson = await _pokemonService.GetPokemon(name);
            if (pokemonJson == null) return NotFound();

            var trsnaslatePokemon = await _translatePokemon.Translate(pokemonJson.ToPokemon());

            return Ok(trsnaslatePokemon);

        }
    }
}
