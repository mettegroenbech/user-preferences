using System;

namespace PreferenceManagement.API.Controllers.Models.Response
{
    public class UserPreferenceResponse
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
    }
}
