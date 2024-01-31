using Api.Models;

namespace Api.Processor
{
    public class BaseCostBenefitProcessor : IBenefitProcessor, IEmployeeProcessor
    {
        private readonly decimal _benefitBaseCost;
        public BaseCostBenefitProcessor(IConfiguration configurationRoot) 
        {
            _benefitBaseCost = configurationRoot.GetValue<decimal>("Benefit:BaseCost");
        }
        public decimal CalculateBenefit(Employee employee)
        {
            return _benefitBaseCost;
        }
    }
}
