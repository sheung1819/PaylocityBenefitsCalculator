using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ApiTests.UnitTests
{
    internal static class ConfigurationHelper
    {
        private static readonly Dictionary<string, string> ConfigDictionary = new()
        {
            { "Benefit:BaseCost", "1000" },
            { "Benefit:DependentAgeCost", "200" },
            { "Benefit:DependentAgeCheck", "50" }
        };

        public static IConfiguration Configuration
        {
            get
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(ConfigDictionary)
                    .Build();

                return configuration;
            }
        }
    }
}
