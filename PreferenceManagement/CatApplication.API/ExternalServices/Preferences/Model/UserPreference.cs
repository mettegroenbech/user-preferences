using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatApplication.API.ExternalServices.Preferences.Model
{
    public class UserPreference
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
    }
}
