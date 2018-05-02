using System.Threading.Tasks;

namespace Tatar.Services
{
    public interface ITranslator
    {
        Task<string> Translate(string words); 
    }
}
