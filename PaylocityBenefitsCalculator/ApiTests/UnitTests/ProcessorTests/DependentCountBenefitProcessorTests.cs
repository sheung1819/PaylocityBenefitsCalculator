using Api.Models;
using Api.Processor;
using Api.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ApiTests.UnitTests.ProcessorTests
{
    public class DependentCountBenefitProcessorTests
    {
        [Fact]
        public void DependentCountBenefit_Should_Calculate_Correct_Cost()
        {
            var mockService = new Mock<IDependentQualifyService>();
            mockService.Setup(x => x.GetDependents(It.IsAny<Employee>())).Returns(new List<Dependent> { new Dependent() });

            var processor = new DependentCountBenefitProcessor(ConfigurationHelper.Configuration, mockService.Object);
            var result = processor.CalculateBenefit(new Employee());

            Assert.True(result == 200);

        }

        [Fact]
        public void DependentCountBenefit_Should_Calculate_No_Dependent()
        {
            var mockService = new Mock<IDependentQualifyService>();
            mockService.Setup(x => x.GetDependents(It.IsAny<Employee>())).Returns(new List<Dependent>());

            var processor = new DependentCountBenefitProcessor(ConfigurationHelper.Configuration, mockService.Object);
            var result = processor.CalculateBenefit(new Employee());

            Assert.True(result == 0);

        }
    }
}
