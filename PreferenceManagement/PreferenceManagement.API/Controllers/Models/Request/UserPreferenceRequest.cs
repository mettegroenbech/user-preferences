using System;

namespace PreferenceManagement.API.Controllers.Models.Request
{
    public class UserPreferenceRequest
    {
        public string UserId { get; set; }
        public string Value { get; set; }
        public Guid PreferenceId { get; set; }
    }
}
