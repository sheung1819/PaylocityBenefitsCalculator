using Api.Models;
using Api.Processor;
using Api.Services;
using Moq;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ApiTests.UnitTests.ProcessorTests
{
    public class DependentAgeBenefitProcessorTest
    {
        [Fact]
        public void DependentAgeBenefitProcessor_Should_Calculate_no_dependent()
        {
            var mockService = new Mock<IDependentQualifyService>();
            mockService.Setup(x => x.GetDependents(It.IsAny<Employee>())).Returns(new List<Dependent>());

            var processor = new DependentAgeBenefitProcessor(ConfigurationHelper.Configuration, mockService.Object);            
            var result = processor.CalculateBenefit(new Employee());

            Assert.True(result == 0);
        }

        [Fact]
        public void DependentAgeBenefitProcessor_Should_Calculate_one_dependent()
        {
            var mockService = new Mock<IDependentQualifyService>();
            mockService.Setup(x => x.GetDependents(It.IsAny<Employee>())).Returns(new List<Dependent> { new Dependent { DateOfBirth = new System.DateTime(1970, 1, 1) } });

            var processor = new DependentAgeBenefitProcessor(ConfigurationHelper.Configuration, mockService.Object);
            var employee = new Employee();
            employee.Dependents.Add(
                new Dependent
                {
                    DateOfBirth = new System.DateTime(1970, 1, 1),
                });
            var result = processor.CalculateBenefit(employee);

            Assert.True(result == 200);
        }

        [Fact]
        public void DependentAgeBenefitProcessor_Should_Calculate_one_dependent_Not_Over_50()
        {
            var mockService = new Mock<IDependentQualifyService>();
            mockService.Setup(x => x.GetDependents(It.IsAny<Employee>())).Returns(new List<Dependent> { new Dependent { DateOfBirth = new System.DateTime(2022, 1, 1) } });

            var processor = new DependentAgeBenefitProcessor(ConfigurationHelper.Configuration, mockService.Object);
            var employee = new Employee();
            employee.Dependents.Add(
                new Dependent
                {
                    DateOfBirth = new System.DateTime(2022, 1, 1),
                });
            var result = processor.CalculateBenefit(employee);

            Assert.True(result == 0);
        }
    }
}
