using CatApplication.API.Configurations;
using Microsoft.Extensions.Options;
using PreferenceManagement.API.Infrastructure.ExternalServices.Cat.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PreferenceManagement.API.Infrastructure.ExternalServices
{
    public class CatService : ICatService
    {
        private readonly ApplicationOptions _options;

        public CatService(IOptions<ApplicationOptions> options)
        {
            _options = options.Value;
        }

        public async Task<CatFact> GetCatFact(int? maxLength = null)
        {
            var route = "/fact";
            if(maxLength != null && maxLength > 0)
            {
                route += $"?max_length={maxLength}";
            }
            var url = new Uri(string.Concat(_options.ExternalServices.CatService.BaseAddress, route));
            
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<CatFact>(responseContent, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });
        }
    }
}
