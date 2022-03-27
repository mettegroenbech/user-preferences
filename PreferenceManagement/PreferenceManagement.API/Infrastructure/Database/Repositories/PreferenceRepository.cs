using Microsoft.EntityFrameworkCore;
using PreferenceManagement.API.Domain.Entities;
using PreferenceManagement.API.Infrastructure.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreferenceManagement.API
{
    public class PreferenceRepository : IPreferenceRepository
    {
        private readonly PreferenceContext _context;

        public PreferenceRepository(PreferenceContext preferenceContext)
        {
            _context = preferenceContext;
        }

        public async Task AddSolutionPreference(Preference preference)
        {
            _context.Preferences.Add(preference);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserPreferenceResponse>> GetSolutionPreferences(string solution, string userId)
        {
            return await _context.UserPreferences
                .Include(x => x.Preference)
                .Where(x => x.Preference.Solution == solution && x.UserId == userId)
                .Select(x => new UserPreferenceResponse { Id = x.Id, Key = x.Preference.Key, Value = x.Value, UserId = x.UserId }).ToListAsync();
        }

        public async Task AddUserPreference(UserPreference preference)
        {
            _context.UserPreferences.Add(preference);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Preference>> GetPredefinedPreferences()
        {
            return await _context.Preferences.ToListAsync();
        }

        public async Task<IEnumerable<UserPreference>> GetUserPreferences()
        {
            return await _context.UserPreferences.ToListAsync();
        }

        public async Task<IEnumerable<UserPreference>> GetUserPreferences(string userId)
        {
            return await _context.UserPreferences
                .Include(x => x.Preference)
                .Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
