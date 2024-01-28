using Api.Models;

namespace Api.Processor
{
    public class EmployeeSalaryBenefitProcessor : IBenefitProcessor
    {
        private decimal _salaryBracket;
        private decimal _salaryBracketPercent;
        public EmployeeSalaryBenefitProcessor(IConfiguration configuration) 
        {
            _salaryBracket = configuration.GetValue<decimal>("Benefit:SalaryBracket");
            _salaryBracket = configuration.GetValue<decimal>("Benefit:SalaryBracketPercent");
        }
        public decimal CalculateBenefit(Employee employee)
        {
            if (employee.Salary >= _salaryBracketPercent)
            {
                return employee.Salary * (_salaryBracket/ 100);
            }

            return 0;
        }
    }
}
