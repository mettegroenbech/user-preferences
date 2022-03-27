using CatApplication.API.ExternalServices.Preferences.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreferenceManagement.API.Infrastructure.ExternalServices
{
    public interface IPreferenceManagementService
    {
        Task<List<UserPreference>> GetUserPreference(string user);
    }
}
