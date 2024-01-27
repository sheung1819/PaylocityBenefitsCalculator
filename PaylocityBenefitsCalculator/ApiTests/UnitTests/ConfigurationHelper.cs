using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ApiTests.UnitTests
{
    internal static class ConfigurationHelper
    {
        private static readonly Dictionary<string, string> ConfigDictionary = new()
        {
            { "Benefit:BenefitBaseCost", "1000" },
            { "Benefit:BenefitDependentAgeCost", "200" }
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
