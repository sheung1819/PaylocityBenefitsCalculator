using Api.Models;
using Api.Services;

namespace Api.Processor
{
    public class DependentCountBenefitProcessor : IBenefitProcessor, IDependentProcessor
    {
        private readonly decimal _dependentCost;
        private readonly IDependentQualifyService _qualifyService;
        public DependentCountBenefitProcessor(IConfiguration configuration, IDependentQualifyService dependentQualifyService)         
        {
            _dependentCost = configuration.GetValue<decimal>("Benefit:DependentCost");
            _qualifyService = dependentQualifyService;
        } 
        public decimal CalculateBenefit(Employee employee)
        {
            var dependents = _qualifyService.GetDependents(employee);
            return dependents.Count() * _dependentCost; 
        }
    }
}
