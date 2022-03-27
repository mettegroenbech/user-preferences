using PreferenceManagement.API.Infrastructure.ExternalServices.Cat.Models;
using System.Threading.Tasks;

namespace PreferenceManagement.API.Infrastructure.ExternalServices
{
    public interface ICatService
    {
        Task<CatFact> GetCatFact(int? maxLength = null);
    }
}
