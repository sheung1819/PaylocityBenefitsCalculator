using Api.Dtos.Paycheck;
using Api.Models;
using Api.Repositories;
using Api.Services;
using AutoMapper;
using Moq;
using Xunit;

namespace ApiTests.UnitTests
{
    public class PaycheckServiceTests
    {
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
            mockMapper.Setup(x => x.Map<GetPaycheckDto>(It.IsAny<Paycheck>())).Returns(new GetPaycheckDto());   

            var paycheckService = new PaycheckService(mockMapper.Object, mockEmployeeRepository.Object, mockBenefitService.Object, mockMonthlyPaycheckCalculator.Object);
            var result = paycheckService.CalculateMonthlyPaycheck(11);
            Assert.NotNull(result);

        }
        [Fact]
        public void PaycheckService_Should_Return_Null_When_Employee_Not_Found()
        {
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            mockEmployeeRepository
                .Setup(x => x.GetEmployeeByID(It.IsAny<int>()))
                .Returns((Employee)null);

            var mockBenefitService = new Mock<IBenefitService>();
            mockBenefitService
                .Setup(x => x.Calculate(It.IsAny<Employee>()))
                .Returns(1000);

            var mockMonthlyPaycheckCalculator = new Mock<IMonthlyPaycheckCalculator>();
            mockMonthlyPaycheckCalculator
                .Setup(x => x.Calculate(It.IsAny<Paycheck>()));

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<GetPaycheckDto>(It.IsAny<Paycheck>())).Returns(new GetPaycheckDto());

            var paycheckService = new PaycheckService(mockMapper.Object, mockEmployeeRepository.Object, mockBenefitService.Object, mockMonthlyPaycheckCalculator.Object);
            var result = paycheckService.CalculateMonthlyPaycheck(11);
            Assert.Null(result);

        }


    }
}
