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
    public class PreferenceDefinitionsController : ControllerBase
    {
        private readonly IPreferenceRepository _preferenceRepository;

        public PreferenceDefinitionsController(IPreferenceRepository preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;
        }

        // [Authorize("update:solution")]
        [Authorize]
        [HttpPost("Solution")]
        public async Task<OkResult> AddSolutionPreference([FromBody] PreferenceDefinitionRequest preferenceRequest)
        {
            var preference = new PreferenceDefinition { Key = preferenceRequest.Key, Level = Level.Solution, Solution = preferenceRequest.Solution };
            await _preferenceRepository.AddPreferenceDefintion(preference);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IEnumerable<PreferenceDefinitionResponse>> GetPreferenceDefinitions()
        {
            var preferenceDefintions = await _preferenceRepository.GetPreferenceDefinitions();
            return preferenceDefintions.Select(x => new PreferenceDefinitionResponse { Id = x.Id, Key = x.Key, Level = x.Level, Solution = x.Solution });
        }

        // [Authorize("update:universal")]
        [HttpPost("Universal")]
        public async Task<OkResult> AddUniversalPreference([FromBody] PreferenceDefinitionRequest preferenceRequest)
        {
            var preference = new PreferenceDefinition { Key = preferenceRequest.Key, Level = Level.Universal, Solution = preferenceRequest.Solution };
            await _preferenceRepository.AddPreferenceDefintion(preference);
            return Ok();
        }
    }
}
