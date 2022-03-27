using PreferenceManagement.API.Controllers.Models.Response;
using PreferenceManagement.API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreferenceManagement.API
{
    public interface IPreferenceRepository
    {
        Task AddPreferenceDefintion(PreferenceDefinition preference);
        Task<IEnumerable<PreferenceDefinition>> GetPreferenceDefinitions();
        Task AddUserPreference(UserPreference userPreference);
        Task<IEnumerable<UserPreference>> GetUsersSolutionPreferences(string solution, string userId);
    }
}
