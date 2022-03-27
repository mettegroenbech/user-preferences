using PreferenceManagement.API.Domain.Entities;
using System;

namespace PreferenceManagement.API.Controllers.Models.Response
{
    public class PreferenceDefinitionResponse
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public Level Level { get; set; }
        public string Solution { get; set; }
    }
}
