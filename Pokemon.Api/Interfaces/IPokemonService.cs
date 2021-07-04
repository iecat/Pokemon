using System.Threading.Tasks;

namespace Pokemon.Api.Interfaces
{
    public interface IPokemonService
    {
        public Task<Pokemon.Api.Model.PokemonJson> GetPokemon(string name);
    }
}
