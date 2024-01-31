using Api.Models;
using Api.Services;

namespace Api.Processor
{
    public class DependentAgeBenefitProcessor : IBenefitProcessor, IDependentProcessor
    {
        private readonly decimal _benefitDependentAgeCost;
        private readonly decimal _benefitDependentAgeCheck;
        private readonly IDependentQualifyService _dependentQualifyService;
        public DependentAgeBenefitProcessor(IConfiguration configuration, IDependentQualifyService dependentQualifyService)
        {
            _benefitDependentAgeCost = configuration.GetValue<decimal>("Benefit:DependentAgeCost");
            _benefitDependentAgeCheck = configuration.GetValue<decimal>("Benefit:DependentAgeCheck");
            _dependentQualifyService = dependentQualifyService;
        }
        public decimal CalculateBenefit(Employee employee)
        {
            if(!employee.Dependents.Any()) 
            {
                return 0;
            }

            var dependents =  _dependentQualifyService.GetDependents(employee);

            var dependentCount = dependents.Where(x => Helper.CalculateAgeHelper.CalculateAge(x.DateOfBirth) > _benefitDependentAgeCheck);
            return dependentCount.Count() * _benefitDependentAgeCost;
        }
    }
}
