using PreferenceManagement.API.Domain.Entities;
using System;

namespace PreferenceManagement.API.Controllers.Models.Request
{
    public class PreferenceDefinitionRequest
    {
        public string Key { get; set; }
        public string Solution { get; set; }
    }
}
