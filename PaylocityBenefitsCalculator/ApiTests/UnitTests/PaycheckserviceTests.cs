using Api.Models;
using Api.Processor;
using Api.Repositories;
using Api.Services;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ApiTests.UnitTests
{
    public class PaycheckServiceTests
    {
        private Mock<BaseCostBenefitProcessor> _mockBaseCost;
        private List<IBenefitProcessor> _processors = new List<IBenefitProcessor>();
        public PaycheckServiceTests() 
        {
            _mockBaseCost = new Mock<BaseCostBenefitProcessor>(ConfigurationHelper.Configuration);

            //_processors.Add(_mockBaseCost.Object);

        
        }


        [Fact]
        public void PaycheckService_Should_Calculate_Monthly_Paycheck()
        { 
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            mockEmployeeRepository
                .Setup(x => x.GetEmployeeByID(It.IsAny<int>()))
                .Returns(new Api.Models.Employee());

            var mockBenefitService = new Mock<IBenefitService>();
            mockBenefitService
                .Setup(x => x.Calculate(It.IsAny<Employee>()))
                .Returns(1000);

            var mockMonthlyPaycheckCalculator = new Mock<IMonthlyPaycheckCalculator>();
            mockMonthlyPaycheckCalculator
                .Setup(x => x.Calculate(It.IsAny<Paycheck>()));

            var mockMapper = new Mock<IMapper>();

            var paycheckService = new PaycheckService(mockMapper.Object, mockEmployeeRepository.Object, mockBenefitService.Object, mockMonthlyPaycheckCalculator.Object);
            var result = paycheckService.CalculateMonthlyPaycheck(11);
            Assert.NotNull(result);

        }

        
        
    }
}
