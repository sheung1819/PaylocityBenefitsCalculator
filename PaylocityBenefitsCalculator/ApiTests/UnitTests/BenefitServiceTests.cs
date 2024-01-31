using Api.Models;
using Api.Processor;
using Api.Services;
using Moq;
using Xunit;

namespace ApiTests.UnitTests
{
    public class BenefitServiceTests
    {

        [Fact]
        public void BenefitService_Should_Calculate_Benefit()
        {
            var processor = new Mock<IBenefitProcessor>();
            processor.Setup(x => x.CalculateBenefit(It.IsAny<Employee>())).Returns(1000);

            var mockProcessorFactory = new Mock<IProcessorFactory>();
            mockProcessorFactory.Setup(x => x.Create(It.Is<string>(x => x == "BaseCostBenefitProcessor"))).Returns(processor.Object);


            var mockDependentFactory = new Mock<DependentBenefitProcessorFactory>();
            mockProcessorFactory.Setup(x => x.Create(It.Is<string>(x => x == "BaseCostBenefitProcessor"))).Returns(processor.Object);

            var benefitService = new BenefitService(mockProcessorFactory.Object, mockDependentFactory.Object);
            var result = benefitService.Calculate(new Employee());

            Assert.True(result == 1000);
        }

        [Fact]
        public void WhenEmployeeHasDependent_Should_Not_Calculate_Benefit_When_No_Dependents()
        {
            //var processor = new Mock<IBenefitProcessor>();
            //processor.Setup(x => x.CalculateBenefit(It.IsAny<Employee>())).Returns(100);            
            
            //var mockProcessorFactory = new Mock<IProcessorFactory>();
            //mockProcessorFactory.Setup(x => x.Create(It.Is<string>(x => x == "DependentCountBenefitProcessor"))).Returns(processor.Object);
           
            //var benefitService = new BenefitService(mockProcessorFactory.Object);
            //var result = benefitService.Calculate(new Employee());

            //Assert.True(result == 0);
        }
    }
}
