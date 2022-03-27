using Microsoft.EntityFrameworkCore;
using System;

namespace PreferenceManagement.API.Domain.Entities
{
    [Index(nameof(UserId), nameof(PreferenceId), IsUnique = true)]
    public class UserPreference
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }
        public Guid PreferenceId { get; set; }

        public PreferenceDefinition Preference { get; set; }
    }
}
