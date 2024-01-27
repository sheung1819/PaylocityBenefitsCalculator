using Api.Models;

namespace Api.Processor
{
    public class DependentAgeBenefitProcessor : IBenefitProcessor
    {
        private readonly decimal _benefitDependentAgeCost; 
        public DependentAgeBenefitProcessor(IConfiguration configuration)
        {
            _benefitDependentAgeCost = configuration.GetValue<decimal>("Benefit:BenefitDependentAgeCost");
        }
        public decimal CalculateBenefit(Employee employee)
        {
            var dependents = employee.Dependents.Where(x => Helper.CalculateAgeHelper.CalculateAge(x.DateOfBirth) > 50);

            return dependents.Count() * _benefitDependentAgeCost;
        }
    }
}
