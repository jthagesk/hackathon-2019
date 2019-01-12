using System;

namespace api.Infrastructure
{
    public class HostingEnvironment
    {
        public HostingEnvironment()
        {
            EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "";
        }

        public string EnvironmentName { get; set; }

        public bool IsDevelopment() => EnvironmentName.Equals("Development", StringComparison.InvariantCultureIgnoreCase);
        public bool IsDev() => EnvironmentName.Equals("dev", StringComparison.InvariantCultureIgnoreCase);
        public bool IsTest() => EnvironmentName.Equals("test", StringComparison.InvariantCultureIgnoreCase);
        public bool IsProduction() => EnvironmentName.Equals("prod", StringComparison.InvariantCultureIgnoreCase);
    }
}
