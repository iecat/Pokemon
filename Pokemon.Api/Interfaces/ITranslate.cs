using Pokemon.Api.Services;
using System.Threading.Tasks;

namespace Pokemon.Api.Interfaces
{
    public interface ITranslate
    {
        public Task<string> Translate(string stringToTranslate, TranslationType translationType);
    }
}
