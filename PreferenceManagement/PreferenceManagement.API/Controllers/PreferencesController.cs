using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PreferenceManagement.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreferenceManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreferencesController : ControllerBase
    {
        private readonly ILogger<PreferencesController> _logger;
        private readonly IPreferenceRepository _preferenceRepository;

        public PreferencesController(ILogger<PreferencesController> logger, IPreferenceRepository preferenceRepository)
        {
            _logger = logger;
            _preferenceRepository = preferenceRepository;
        }

        [HttpPost("Universal")]
        // [Authorize("update:universal")]
        public OkResult AddUniversalPreference([FromBody] Preference preference)
        {
            _logger.LogInformation($"{nameof(AddUniversalPreference)} was called.");
            return Ok();
        }

        [HttpPut("Universal/{id}")]
        // [Authorize("update:universal")]
        public OkResult UpdateUniversalPreference([FromRoute]Guid id)
        {
            _logger.LogInformation($"{nameof(UpdateUniversalPreference)} was called.");
            return Ok();
        }

        // [Authorize("update:solution")]
        [HttpPost("Solution")]
        public async Task<OkResult> AddSolutionPreference([FromBody] Preference preference)
        {
            await _preferenceRepository.AddSolutionPreference(preference);
            return Ok();
        }

        // [Authorize("update:solution")]
        [HttpPut("Solution/{id}")]
        public OkResult UpdateSolutionPreference([FromRoute] Guid id)
        {
            _logger.LogInformation(nameof(UpdateSolutionPreference));
            return Ok();
        }

        // [Authorize]
        [HttpPost("Solution/{solution}/{userId}")]
        public async Task<IEnumerable<UserPreference>> GetUserPreferences([FromRoute] string solution, [FromRoute] string userId)
        {
            return await _preferenceRepository.GetSolutionPreferences(solution, userId);
        }

        // [Authorize]
        [HttpPost("User")]
        public async Task<OkResult> AddUserPreference([FromBody] UserPreference preference)
        {
            await _preferenceRepository.AddUserPreference(preference);
            return Ok();
        }

        // [Authorize]
        [HttpGet("User/{userId}")]
        public async Task<IEnumerable<UserPreference>> GetUserPreferences([FromRoute] string userId)
        {
            return await _preferenceRepository.GetUserPreferences(userId);
        }

        // [Authorize]
        [HttpPut("User/{preferenceId}")]
        public OkResult UpdateUserPreference([FromRoute] Guid preferenceId)
        {
            
            return Ok();
        }
        
        [HttpGet("")]
        public async Task<IEnumerable<Preference>> GetPreferencesAsync()
        {
            return await _preferenceRepository.GetPredefinedPreferences();
        }
    }
}
