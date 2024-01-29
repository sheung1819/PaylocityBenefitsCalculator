using Api.Models;
using Api.Processor;
using Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.UnitTests
{
    public class BenefitServiceTests
    {

        [Fact]
        public void BenefitService_Should_Calculate_Benefit()
        {
            var _processors = new List<IBenefitProcessor>();

            var dependentQualifyService = new Mock<IDependentQualifyService>();

            dependentQualifyService.Setup(x => x.GetDependents(It.IsAny<Employee>()))                
                .Returns(new List<Dependent> { new Dependent() });

            var baseCostBenefit = new Mock<BaseCostBenefitProcessor>(ConfigurationHelper.Configuration).Object;
            var ageBenefit = new Mock<DependentAgeBenefitProcessor>(ConfigurationHelper.Configuration, dependentQualifyService.Object).Object;
            var countBenefit = new Mock<DependentCountBenefitProcessor>(ConfigurationHelper.Configuration, dependentQualifyService.Object).Object;
            var salaryBenefit = new Mock<EmployeeSalaryBenefitProcessor>(ConfigurationHelper.Configuration).Object;

            _processors.Add(baseCostBenefit);
            _processors.Add(ageBenefit);
            _processors.Add(countBenefit);
            _processors.Add(salaryBenefit);
            
            var benefitService = new BenefitService(_processors);
            var result = benefitService.Calculate(new Employee());

            Assert.True(result == 1000);
        }
    }
}
