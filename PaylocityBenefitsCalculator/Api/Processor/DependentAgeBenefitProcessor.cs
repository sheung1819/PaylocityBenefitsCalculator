using Api.Models;

namespace Api.Processor
{
    public class DependentAgeBenefitProcessor : IBenefitProcessor
    {
        public decimal CalculateBenefit(Employee employee)
        {
            var dependents = employee.Dependents.Where(x => x.age)

        }
    }
}
