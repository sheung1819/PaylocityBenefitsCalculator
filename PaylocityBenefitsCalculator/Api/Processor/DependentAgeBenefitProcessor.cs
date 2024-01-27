using Api.Models;

namespace Api.Processor
{
    public class DependentAgeBenefitProcessor : IBenefitProcessor
    {
        private readonly decimal _benefitDependentAgeCost;
        private readonly decimal _benefitDependentAgeCheck;
        public DependentAgeBenefitProcessor(IConfiguration configuration)
        {
            _benefitDependentAgeCost = configuration.GetValue<decimal>("Benefit:BenefitDependentAgeCost");
            _benefitDependentAgeCheck = configuration.GetValue<decimal>("Benefit:BenefitDependentAgeCheck");
        }
        public decimal CalculateBenefit(Employee employee)
        {
            if(!employee.Dependents.Any()) 
            {
                return 0;
            }

            var dependents = employee.Dependents.Where(x => Helper.CalculateAgeHelper.CalculateAge(x.DateOfBirth) > _benefitDependentAgeCheck);

            return dependents.Count() * _benefitDependentAgeCost;
        }
    }
}
