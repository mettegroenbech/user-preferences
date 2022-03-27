using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PreferenceManagement.API.Controllers.Models.Request;
using PreferenceManagement.API.Controllers.Models.Response;
using PreferenceManagement.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreferenceManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserPreferencesController : ControllerBase
    {
        private readonly IPreferenceRepository _preferenceRepository;

        public UserPreferencesController(IPreferenceRepository preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;
        }

        // [Authorize]
        [HttpPost("")]
        public async Task<OkResult> AddUserPreference([FromBody] UserPreferenceRequest userPreferenceRequest)
        {
            var userPreference = new UserPreference { PreferenceId = userPreferenceRequest.PreferenceId, UserId = userPreferenceRequest.UserId, Value = userPreferenceRequest.Value };
            await _preferenceRepository.AddUserPreference(userPreference);
            return Ok();
        }

        // [Authorize]
        [HttpGet("{solution}/{userId}")]
        public async Task<IEnumerable<UserPreferenceResponse>> GetUsersSolutionPreferences([FromRoute] string solution, [FromRoute] string userId)
        {
            var userPreferences = await _preferenceRepository.GetUsersSolutionPreferences(solution, userId);
            return userPreferences.Select(x => new UserPreferenceResponse { Id = x.Id, Key = x.Preference.Key, Value = x.Value, UserId = x.UserId });
        }
    }
}
