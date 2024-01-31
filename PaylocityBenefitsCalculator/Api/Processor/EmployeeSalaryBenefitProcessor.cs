using Api.Models;

namespace Api.Processor
{
    public class EmployeeSalaryBenefitProcessor : IBenefitProcessor, IEmployeeProcessor
    {
        private decimal _salaryBracket;
        private decimal _salaryBracketPercent;
        public EmployeeSalaryBenefitProcessor(IConfiguration configuration) 
        {
            _salaryBracket = configuration.GetValue<decimal>("Benefit:SalaryBracket");
            _salaryBracketPercent = configuration.GetValue<decimal>("Benefit:SalaryBracketPercent");
        }
        public decimal CalculateBenefit(Employee employee)
        {
            if (employee.Salary >= _salaryBracket)
            {
                return employee.Salary * (_salaryBracketPercent / 100);
            }

            return 0;
        }
    }
}
