using Microsoft.EntityFrameworkCore;
using PreferenceManagement.API.Controllers.Models.Response;
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

        public async Task AddPreferenceDefintion(PreferenceDefinition preference)
        {
            _context.PreferenceDefinitions.Add(preference);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PreferenceDefinition>> GetPreferenceDefinitions()
        {
            return await _context.PreferenceDefinitions.ToListAsync();
        }

        public async Task<IEnumerable<UserPreference>> GetUsersSolutionPreferences(string solution, string userId)
        {
            return await _context.UserPreferences
                .Include(x => x.Preference)
                .Where(x => x.Preference.Solution == solution && x.UserId == userId)
                .ToListAsync();
        }

        public async Task AddUserPreference(UserPreference preference)
        {
            _context.UserPreferences.Add(preference);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserPreference>> GetAllUserPreferences(string userId)
        {
            return await _context.UserPreferences
                .Include(x => x.Preference)
                .Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
