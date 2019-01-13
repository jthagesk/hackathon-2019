using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;

namespace api.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddUserSecretsIfDevelopment(this IConfigurationBuilder builder) =>
            new HostingEnvironment().IsDevelopment() ?
                builder.AddUserSecrets<Program>(optional: true) :
                builder;
    }
}
