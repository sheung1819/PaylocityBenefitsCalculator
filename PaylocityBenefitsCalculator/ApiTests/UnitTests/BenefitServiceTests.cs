using Api.Models;
using Api.Processor;
using Api.Services;
using Moq;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace ApiTests.UnitTests
{
    public class BenefitServiceTests
    {

        [Fact]
        public void BenefitService_Should_Calculate_Benefit()
        {
            var factory = new EmployeeBenefitProcessorFactory(ConfigurationHelper.Configuration);

            var factories = new List<IProcessorFactory>
            {
                factory
            };
            var benefitService = new BenefitService(factories);
            var result = benefitService.Calculate(new Employee());

            Assert.True(result == 1000);
        }

        [Fact]
        public void WhenEmployeeHasDependent_Should_Not_Calculate_Benefit_When_No_Dependents()
        {
            var dependentQualifyService = new Mock<IDependentQualifyService>();
            dependentQualifyService.Setup(x => x.GetDependents(It.IsAny<Employee>()))
                .Returns(new List<Dependent>());

            var factory = new DependentBenefitProcessorFactory(ConfigurationHelper.Configuration, dependentQualifyService.Object);

            var factories = new List<IProcessorFactory>
            {
                factory
            };
            var benefitService = new BenefitService(factories);
            var result = benefitService.Calculate(new Employee());

            Assert.True(result == 0);
        }
    }
}
