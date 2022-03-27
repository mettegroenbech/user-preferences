using CatApplication.API;
using CatApplication.API.Configurations;
using CatApplication.API.ExternalServices.Preferences.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PreferenceManagement.API.Infrastructure.ExternalServices
{
    public class PreferenceManagementService : IPreferenceManagementService
    {
        private readonly ApplicationOptions _options;

        public PreferenceManagementService(IOptions<ApplicationOptions> options)
        {
            _options = options.Value;
        }

        public async Task<List<UserPreference>> GetUserPreference(string user)
        {
            var route = $"/Preferences/Solution/{Constants.ApplicationName}/{user}";
            
            var url = new Uri(string.Concat(_options.ExternalServices.PreferenceManagementService.BaseAddress, route));
            
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<UserPreference>>(responseContent, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });
        }
    }
}
