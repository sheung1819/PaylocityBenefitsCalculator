using Api.Models;

namespace Api.Processor
{
    public class BaseCostBenefitProcessor : IBenefitProcessor
    {
        public decimal CalculateBenefit(Employee employee)
        {
            return 1000;
        }
    }
}
