using Api.Models;
using Api.Processor;
using System.Collections.Concurrent;

namespace Api.Services
{
    public class BenefitService : IBenefitService
    {
        private readonly IEnumerable<IProcessorFactory> _factories;
     
        private const string ProcessorNameSpace = "Api.Processor.";       

        public BenefitService(IEnumerable<IProcessorFactory> factories)
        {
            _factories = factories;          
        }

        public decimal Calculate(Employee employee)
        { 
            var benefitProcessors = new List<IBenefitProcessor?>();

            AddEmployeeBenefitProcessor(benefitProcessors);
            AddDependentBenefitProcessor(employee, benefitProcessors);          

            return ProcessBenefit(employee, benefitProcessors);
           
        }

        private void AddDependentBenefitProcessor(Employee employee, List<IBenefitProcessor?> benefitProcessors)
        {
            if (!employee.Dependents.Any())
            {
                return;
            }

            var factory = _factories.OfType<DependentBenefitProcessorFactory>().FirstOrDefault();
            if (factory == null)
            {
                return;
            }

            var type = typeof(IDependentProcessor);
            var types = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Api"))
                            .SelectMany(s => s.GetTypes())
                            .Where(p => type.IsAssignableFrom(p));

            foreach (var processor in types.Where(x => !x.IsInterface))
            {
                if(processor != null && !string.IsNullOrWhiteSpace(processor.FullName))
                    benefitProcessors.Add(factory.Create(processor.FullName));
            }
        }

        private void AddEmployeeBenefitProcessor(List<IBenefitProcessor?> benefitProcessors)
        {

            var factory = _factories.OfType<EmployeeBenefitProcessorFactory>().FirstOrDefault();           
            if(factory == null) 
            {
                return;
            }

            var type = typeof(IEmployeeProcessor);
            var types = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Api"))
                            .SelectMany(s => s.GetTypes())
                            .Where(p => type.IsAssignableFrom(p));

            foreach (var processor in types.Where(x => !x.IsInterface))
            {
                if (processor != null && !string.IsNullOrWhiteSpace(processor.FullName))
                    benefitProcessors.Add(factory.Create(processor.FullName));
            }
        }       

        private static decimal ProcessBenefit(Employee employee, List<IBenefitProcessor?> processors)
        {
            var benefitCost = new ConcurrentBag<decimal>();

            Parallel.ForEach(processors, processor =>
            {
                if(processor != null)
                    benefitCost.Add(processor.CalculateBenefit(employee));
            });

            return benefitCost.ToList().Sum();
        }
    }
}
