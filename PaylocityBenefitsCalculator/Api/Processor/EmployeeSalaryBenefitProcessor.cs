using Api.Models;

namespace Api.Processor
{
    public class EmployeeSalaryBenefitProcessor : IBenefitProcessor
    {
        public decimal CalculateBenefit(Employee employee)
        {
            if (employee.Salary >= 80000)
            {
                return employee.Salary * 1.02M;
            }

            return 0;
        }
    }
}
