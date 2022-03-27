using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PreferenceManagement.API.Infrastructure.ExternalServices;
using PreferenceManagement.API.Infrastructure.ExternalServices.Cat.Models;
using System.Threading.Tasks;

namespace CatApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatServiceController : ControllerBase
    {
        private readonly ILogger<CatServiceController> _logger;
        private readonly ICatService _catService;
        private readonly IPreferenceManagementService _preferenceManagementService;

        public CatServiceController(ILogger<CatServiceController> logger, ICatService catService, IPreferenceManagementService preferenceManagementService)
        {
            _logger = logger;
            _catService = catService;
            _preferenceManagementService = preferenceManagementService;
        }

        [HttpGet("GetCatFact/{user}")]
        public async Task<CatFact> GetCatFact([FromRoute] string user)
        {
            var userPreferences = await _preferenceManagementService.GetUserPreference(user);
            var maxLengthPreference = userPreferences.Find(x => x.Key == Constants.CatFactMaxLengthPreference);
            if (maxLengthPreference != null)
            {
                var maxLength = int.Parse(maxLengthPreference.Value);
                return await _catService.GetCatFact(maxLength);
            }

            return await _catService.GetCatFact();
        }
    }
}