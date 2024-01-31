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
            { "Benefit:DependentAgeCheck", "50" },
            { "Benefit:SalaryBracket" , "80000"},
            { "Benefit:SalaryBracketPercent" , "2"},
            { "Benefit:QualifyDependentRelationType" , "Child"},
            { "Benefit:DependentCost","200" },
            { "PaycheckPeriod" ,"5" }
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

        public static void OverrideConfigDictionary(string key, string value)
        { 
            if(ConfigDictionary.ContainsKey(key)) 
            {
                ConfigDictionary.Remove(key);            
            }
            ConfigDictionary.Add(key, value);
        }
    }
}
