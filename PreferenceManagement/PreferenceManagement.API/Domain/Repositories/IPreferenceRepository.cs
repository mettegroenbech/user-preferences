using PreferenceManagement.API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreferenceManagement.API
{
    public interface IPreferenceRepository
    {
        Task AddSolutionPreference(Preference preference);
        Task<IEnumerable<UserPreferenceResponse>> GetSolutionPreferences(string solution, string userId);
        Task AddUserPreference(UserPreference userPreference);
        Task<IEnumerable<Preference>> GetPredefinedPreferences();
        Task<IEnumerable<UserPreference>> GetUserPreferences();
        Task<IEnumerable<UserPreference>> GetUserPreferences(string userId);
    }
}
