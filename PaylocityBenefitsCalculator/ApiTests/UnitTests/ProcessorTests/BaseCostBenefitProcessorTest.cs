using Api.Models;
using Api.Processor;
using Xunit;

namespace ApiTests.UnitTests.ProcessorTests
{

    public class BaseCostBenefitProcessorTest
    {
        [Fact]
        public void BaseCostBenefitProcess_Should_Return_BaseBenefitCost()
        {
            var baseCostBenefitProcessor = new BaseCostBenefitProcessor(ConfigurationHelper.Configuration);

            var cost = baseCostBenefitProcessor.CalculateBenefit(new Employee());

            Assert.True(cost == 1000);
        }
    }
    
}
