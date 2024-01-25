using Api.Models;

namespace Api.Processor
{
    public class DependentCountBenefitProcessor : IBenefitProcessor
    {
        public decimal CalculateBenefit(Employee employee)
        {
            return employee.Dependents.Count() * 600; 
        }
    }
}
