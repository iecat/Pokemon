using System.Threading.Tasks;

namespace Pokemon.Api.Interfaces
{
    public interface ITranslatePokemon
    {
        public Task<Pokemon.Api.Model.Pokemon> Translate(Pokemon.Api.Model.Pokemon pokemon);
    }
}
