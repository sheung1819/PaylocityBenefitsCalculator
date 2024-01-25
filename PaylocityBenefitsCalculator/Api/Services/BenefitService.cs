using Api.Models;
using Api.Processor;
using System.Collections.Concurrent;

namespace Api.Services
{
    public class BenefitService : IBenefitService
    {
        private readonly IEnumerable<IBenefitProcessor> _benefitProcessors;
        public BenefitService(IEnumerable<IBenefitProcessor> benefitProcessors)
        {
            _benefitProcessors = benefitProcessors;
        }

        public decimal Calculate(Employee employee)
        {
            var benefitCost = new ConcurrentBag<decimal>();

            Parallel.ForEach(_benefitProcessors, processor =>
            {
                benefitCost.Add(processor.CalculateBenefit(employee));
            });

            return benefitCost.ToList().Sum();
        }
    }
}
