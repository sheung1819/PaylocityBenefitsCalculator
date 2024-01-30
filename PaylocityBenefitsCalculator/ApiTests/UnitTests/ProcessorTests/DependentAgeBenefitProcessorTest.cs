using Api.Models;
using Api.Processor;
using Api.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ApiTests.UnitTests.ProcessorTests
{
    public class DependentAgeBenefitProcessorTest
    {
        [Fact]
        public void WhenNoDependents_ShouldReturnZero()
        {
            var mockService = new Mock<IDependentQualifyService>();
            mockService.Setup(x => x.GetDependents(It.IsAny<Employee>())).Returns(new List<Dependent>());

            var processor = new DependentAgeBenefitProcessor(ConfigurationHelper.Configuration, mockService.Object);            
            var result = processor.CalculateBenefit(new Employee());

            Assert.True(result == 0);
        }

        [Fact]
        public void WhenDependentOver50_ShouldAddToBenefitCost()
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
        public void whhenDependNotOver50_ShouldNotAddAdditionalBenefitCost()
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


        [Fact]
        public void whhenDependOver50_ShouldNotAddAdditionalBenefitCostForDependentUnder50()
        {
            var dependents = new List<Dependent>
            {
                new Dependent
                {
                    DateOfBirth = new System.DateTime(1970, 1, 1)
                } ,
                new Dependent
                {
                    DateOfBirth = new System.DateTime(1970, 4, 1),
                }
            };

            var mockService = new Mock<IDependentQualifyService>();
            mockService.Setup(x => x.GetDependents(It.IsAny<Employee>())).Returns(dependents);

            var processor = new DependentAgeBenefitProcessor(ConfigurationHelper.Configuration, mockService.Object);
            var employee = new Employee();
            employee.Dependents = dependents;
            var result = processor.CalculateBenefit(employee);

            Assert.True(result == 400);
        }
    }
}
