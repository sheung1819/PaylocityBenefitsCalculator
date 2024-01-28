using Api.Models;
using Api.Services;

namespace Api.Processor
{
    public class DependentCountBenefitProcessor : IBenefitProcessor
    {
        private readonly decimal _dependentCost;
        private readonly IDependentQualifyService _qualifyService;
        public DependentCountBenefitProcessor(IConfiguration configuration, DependentQualifyService dependentQualifyService)         
        {
            _dependentCost = configuration.GetValue<decimal>("Benefit:DependentCost");
            _qualifyService = dependentQualifyService;
        } 
        public decimal CalculateBenefit(Employee employee)
        {
            var dependentCount = _qualifyService.GetDependentCount(employee);

            return dependentCount * _dependentCost; 
        }
    }
}
