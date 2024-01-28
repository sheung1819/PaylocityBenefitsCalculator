using Api.Models;
using Api.Processor;
using Xunit;

namespace ApiTests.UnitTests.ProcessorTests
{
    public class EmployeeSalaryBenefitProcessorTest
    {
        [Fact]
        public void EmployeeSalary_Over_Range_Need_To_Add_Percentage()
        {
            var processor = new EmployeeSalaryBenefitProcessor(ConfigurationHelper.Configuration);

            var employee = new Employee
            {
                Salary = 80000m
            };
            var cost = processor.CalculateBenefit(employee);
            Assert.True(cost == 1600);
        }

        [Fact]
        public void EmployeeSalary_Over_Range_No_Need_To_Add_Percentage()
        {
            var processor = new EmployeeSalaryBenefitProcessor(ConfigurationHelper.Configuration);

            var employee = new Employee
            {
                Salary = 10000m
            };
            var cost = processor.CalculateBenefit(employee);
            Assert.True(cost == 0);
        }
    }
}
