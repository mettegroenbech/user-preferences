using System.Collections.Generic;

namespace PreferenceManagement.API.Infrastructure.Configurations
{
    public class ApplicationOptions
    {
        public Endpoint Endpoint { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }
}
