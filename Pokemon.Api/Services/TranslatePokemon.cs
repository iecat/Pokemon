using Pokemon.Api.Interfaces;
using System.Threading.Tasks;

namespace Pokemon.Api.Services
{
    public class TranslatePokemon: ITranslatePokemon
    {
        private readonly ITranslate _translateService;
        public TranslatePokemon(ITranslate translateService)
        {
            _translateService = translateService;
        }

        public async Task<Pokemon.Api.Model.Pokemon> Translate(Pokemon.Api.Model.Pokemon pokemon)
        {
            if (pokemon.IsLegendary || pokemon.Habitat == "cave")
                pokemon.Description = await _translateService.Translate(pokemon.Description, TranslationType.Yoda);
            else pokemon.Description = await _translateService.Translate(pokemon.Description, TranslationType.Shakespeare);
            return pokemon;
        }
    }
}
