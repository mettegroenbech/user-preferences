using System;

namespace PreferenceManagement.API
{
    public class UserPreferenceResponse
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
    }
}
